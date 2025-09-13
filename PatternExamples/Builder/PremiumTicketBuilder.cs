namespace AbsoluteCinema.PatternExamples.Builder;

public class PremiumTicketBuilder : ITicketBuilder
{
    private Ticket _ticket = new();
    private decimal _basePrice = 20.00m;

    public PremiumTicketBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        _ticket = new Ticket
        {
            TicketType = "Premium",
            IsVip = true 
        };
    }

    public ITicketBuilder SetMovie(string movieTitle)
    {
        Console.WriteLine($"[Premium] Setting movie: {movieTitle}");
        _ticket.MovieTitle = movieTitle;
        return this;
    }

    public ITicketBuilder SetShowTime(DateTime showTime)
    {
        Console.WriteLine($"[Premium] Setting show time: {showTime:yyyy-MM-dd HH:mm}");
        _ticket.ShowTime = showTime;
        return this;
    }

    public ITicketBuilder SetCinemaHall(string hall)
    {
        Console.WriteLine($"[Premium] Setting cinema hall: {hall}");
        _ticket.CinemaHall = hall;
        return this;
    }

    public ITicketBuilder SetSeat(int row, int number)
    {
        Console.WriteLine($"[Premium] Setting premium seat: Row {row}, Seat {number}");
        _ticket.SeatRow = row;
        _ticket.SeatNumber = number;
        return this;
    }

    public ITicketBuilder SetVip(bool isVip)
    {
        Console.WriteLine("[Premium] VIP status is always enabled for premium tickets");
        _ticket.IsVip = true;
        return this;
    }

    public ITicketBuilder AddPopcorn()
    {
        Console.WriteLine("[Premium] Adding complimentary premium popcorn");
        _ticket.HasPopcorn = true;
        return this;
    }

    public ITicketBuilder AddDrink()
    {
        Console.WriteLine("[Premium] Adding complimentary premium drink");
        _ticket.HasDrink = true;
        return this;
    }

    public ITicketBuilder SetTicketType(string type)
    {
        Console.WriteLine($"[Premium] Setting ticket type: {type}");
        _ticket.TicketType = type;
        return this;
    }

    public ITicketBuilder CalculatePrice()
    {
        decimal totalPrice = _basePrice;

        if (_ticket.ShowTime.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            totalPrice += 1.00m;

        _ticket.Price = totalPrice;
        Console.WriteLine($"[Premium] Calculated total price: ${totalPrice:F2}");
        return this;
    }

    public Ticket Build()
    {
        var result = _ticket;
        Reset();
        return result;
    }
}