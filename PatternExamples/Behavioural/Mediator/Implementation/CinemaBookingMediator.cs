using AbsoluteCinema.PatternExamples.Behavioural.Mediator.Abstraction;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Mediator.Implementation;

public class CinemaBookingMediator : ICinemaMediator
{
    private readonly List<User> _users = [];
    private readonly List<CinemaHall> _halls = [];

    private NotificationService _notificationService;
    private PaymentSystem _paymentSystem;

    public void RegisterUser(User user) => _users.Add(user);
    public void RegisterHall(CinemaHall hall) => _halls.Add(hall);
    public void RegisterPaymentSystem(PaymentSystem payment) => _paymentSystem = payment;
    public void RegisterNotificationService(NotificationService notification) => _notificationService = notification;

    public void Notify(object sender, string eventType, object? data = null)
    {
        Console.WriteLine($"[Mediator] Processing event: {eventType} from {sender.GetType().Name}");

        switch (eventType)
        {   
            case "BookSeats":
                HandleBooking((sender as User)!, (data as BookingData)!);
                break;

            case "CancelBooking":
                HandleCancellation((sender as User)!);
                break;

            case "PaymentProcessed":
                HandlePaymentSuccess((data as string)!);
                break;

            case "PaymentFailed":
                HandlePaymentFailure((data as string)!);
                break;

            case "CheckAvailability":
                HandleAvailabilityCheck((sender as CinemaHall)!);
                break;

            default:
                Console.WriteLine($"[Mediator] Unknown event type: {eventType}");
                break;
        }
    }

    private void HandleBooking(User user, BookingData booking)
    {
        var hall = _halls.FirstOrDefault(h => h.Name == booking.HallName);

        if (hall == null)
        {
            Console.WriteLine($"[Mediator] Hall '{booking.HallName}' not found");
            _notificationService.SendNotification(user.Name, "Booking failed: Hall not found");
            return;
        }

        if (hall.BookSeats(booking.NumberOfSeats))
        {
            Console.WriteLine($"[Mediator] Booking successful for {user.Name}");

            _paymentSystem.ProcessPayment(user.Name, booking.NumberOfSeats * 125.99m);

            _notificationService.SendNotification(user.Name,
                $"Successfully booked {booking.NumberOfSeats} seats for '{booking.MovieTitle}' in {booking.HallName}");
        }
        else
        {
            Console.WriteLine("[Mediator] Booking failed - not enough seats");
            _notificationService.SendNotification(user.Name, "Booking failed: Not enough available seats");
        }
    }

    private void HandleCancellation(User user)
    {
        Console.WriteLine($"[Mediator] Processing cancellation for {user.Name}");

        foreach (var hall in _halls)
        {
            hall.ReleaseSeats(2);
        }

        _paymentSystem.RefundPayment(user.Name, 125.99m);
        _notificationService.SendNotification(user.Name, "Your booking has been cancelled and refund processed");
    }

    private void HandlePaymentSuccess(string userName)
    {
        Console.WriteLine($"[Mediator] Payment confirmed for {userName}");
        _notificationService.SendNotification(userName, "Payment successful! Enjoy your movie!");
    }

    private void HandlePaymentFailure(string userName)
    {
        Console.WriteLine($"[Mediator] Payment failed for {userName}");
        _notificationService.SendNotification(userName, "Payment failed. Please try again.");
    }

    private void HandleAvailabilityCheck(CinemaHall hall)
    {
        Console.WriteLine($"[Mediator] Availability check for {hall.Name}: {hall.AvailableSeats} seats available");
    }
}