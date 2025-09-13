namespace AbsoluteCinema.PatternExamples.Builder;

public class Ticket
{
    public string MovieTitle { get; set; } = string.Empty;
    public DateTime ShowTime { get; set; } 
    public string CinemaHall { get; set; } = string.Empty;
    public int SeatRow { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public bool IsVip { get; set; }
    public bool HasPopcorn { get; set; }
    public bool HasDrink { get; set; }
    public string TicketType { get; set; } = string.Empty;

    public void ShowTicket()
    {
        Console.WriteLine("===================");
        Console.WriteLine($"Movie: {MovieTitle}");
        Console.WriteLine($"Date & Time: {ShowTime:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"Hall: {CinemaHall}");
        Console.WriteLine($"Seat: Row {SeatRow}, Seat {SeatNumber}");
        Console.WriteLine($"Type: {TicketType}");
        Console.WriteLine($"VIP: {(IsVip ? "Yes" : "No")}");
        Console.WriteLine($"Extras: {(HasPopcorn ? "Popcorn " : "")}{(HasDrink ? "Drink" : "")}");
        Console.WriteLine($"Total Price: ${Price:F2}");
        Console.WriteLine("===================");
    }
}