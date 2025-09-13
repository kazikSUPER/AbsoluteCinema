namespace AbsoluteCinema.PatternExamples.Builder;

public class StandardTicketBuilder : ITicketBuilder
{
    private Ticket _ticket = new();
    private decimal _basePrice = 10.00m;

    public StandardTicketBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        _ticket = new Ticket
        {
            TicketType = "Standard"
        };
    }

    public ITicketBuilder SetMovie(string movieTitle)
    {
        Console.WriteLine($"Setting movie: {movieTitle}");
        _ticket.MovieTitle = movieTitle;
        return this;
    }

    public ITicketBuilder SetShowTime(DateTime showTime)
    {
        Console.WriteLine($"Setting show time: {showTime:yyyy-MM-dd HH:mm}");
        _ticket.ShowTime = showTime;
        return this;
    }

    public ITicketBuilder SetCinemaHall(string hall)
    {
        Console.WriteLine($"Setting cinema hall: {hall}");
        _ticket.CinemaHall = hall;
        return this;
    }

    public ITicketBuilder SetSeat(int row, int number)
    {
        Console.WriteLine($"Setting seat: Row {row}, Seat {number}");
        _ticket.SeatRow = row;
        _ticket.SeatNumber = number;
        return this;
    }

    public ITicketBuilder SetVip(bool isVip)
    {
        Console.WriteLine($"Setting VIP status: {isVip}");
        _ticket.IsVip = isVip;
        return this;
    }

    public ITicketBuilder AddPopcorn()
    {
        Console.WriteLine("Adding popcorn to order");
        _ticket.HasPopcorn = true;
        return this;
    }

    public ITicketBuilder AddDrink()
    {
        Console.WriteLine("Adding drink to order");
        _ticket.HasDrink = true;
        return this;
    }

    public ITicketBuilder SetTicketType(string type)
    {
        Console.WriteLine($"Setting ticket type: {type}");
        _ticket.TicketType = type;
        return this;
    }

    public ITicketBuilder CalculatePrice()
    {
        decimal totalPrice = _basePrice;

        if (_ticket.IsVip)
            totalPrice += 5.00m;

        if (_ticket.HasPopcorn)
            totalPrice += 4.50m;

        if (_ticket.HasDrink)
            totalPrice += 3.50m;

        if (_ticket.ShowTime.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            totalPrice += 2.00m;

        _ticket.Price = totalPrice;
        Console.WriteLine($"Calculated total price: ${totalPrice:F2}");
        return this;
    }

    public Ticket Build()
    {
        var result = _ticket;
        Reset();
        return result;
    }
}