using AbsoluteCinema.PatternExamples.Behavioural.Mediator.Abstraction;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Mediator.Implementation;

public class User(string name, ICinemaMediator mediator) : BaseComponent(mediator)
{
    public string Name { get; } = name;

    public void BookSeats(string hallName, string movieTitle, int numberOfSeats)
    {
        Console.WriteLine($"[User {Name}] Attempting to book {numberOfSeats} seats for '{movieTitle}' in {hallName}");
        Mediator.Notify(this, "BookSeats", new BookingData
        {
            HallName = hallName,
            MovieTitle = movieTitle,
            NumberOfSeats = numberOfSeats
        });
    }

    public void CancelBooking()
    {
        Console.WriteLine($"[User {Name}] Requesting booking cancellation");
        Mediator.Notify(this, "CancelBooking");
    }
}