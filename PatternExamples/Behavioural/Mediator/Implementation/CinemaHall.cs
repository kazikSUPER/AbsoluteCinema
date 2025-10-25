using AbsoluteCinema.PatternExamples.Behavioural.Mediator.Abstraction;

namespace AbsoluteCinema.PatternExamples.Behavioural.Mediator.Implementation;

public class CinemaHall(string name, int totalSeats, ICinemaMediator mediator) : BaseComponent(mediator)
{
    public string Name { get; } = name;
    public int TotalSeats { get; } = totalSeats;
    public int AvailableSeats { get; private set; } = totalSeats;

    public bool BookSeats(int numberOfSeats)
    {
        if (numberOfSeats <= AvailableSeats)
        {
            AvailableSeats -= numberOfSeats;
            Console.WriteLine($"[CinemaHall {Name}] Booked {numberOfSeats} seats. Available: {AvailableSeats}/{TotalSeats}");
            return true;
        }

        Console.WriteLine($"[CinemaHall {Name}] Cannot book {numberOfSeats} seats. Only {AvailableSeats} available");
        return false;
    }

    public void ReleaseSeats(int numberOfSeats)
    {
        AvailableSeats = Math.Min(AvailableSeats + numberOfSeats, TotalSeats);
        Console.WriteLine($"[CinemaHall {Name}] Released {numberOfSeats} seats. Available: {AvailableSeats}/{TotalSeats}");
    }

    public void CheckAvailability()
    {
        Console.WriteLine($"[CinemaHall {Name}] Checking availability...");
        Mediator.Notify(this, "CheckAvailability");
    }
}