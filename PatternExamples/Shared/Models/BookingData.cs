namespace AbsoluteCinema.PatternExamples.Shared.Models;

public class BookingData
{
    public int NumberOfSeats { get; set; }
    public required string HallName { get; set; }
    public required string MovieTitle { get; set; }
}