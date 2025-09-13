namespace AbsoluteCinema.PatternExamples.Builder;

public class TicketBuilder
{
    public required ITicketBuilder Builder;

    public void SetBuilder(ITicketBuilder builder)
    {
        Builder = builder;
    }

    public Ticket BuildBasicTicket(
        string movie, 
        DateTime showTime, 
        string hall, 
        int row, 
        int seat
    )
    {
        Console.WriteLine("tcktBldr: Building basic ticket...");
        return Builder
            .SetMovie(movie)
            .SetShowTime(showTime)
            .SetCinemaHall(hall)
            .SetSeat(row, seat)
            .CalculatePrice()
            .Build();
    }

    public Ticket BuildFullExperienceTicket(
        string movie,
        DateTime showTime,
        string hall,
        int row,
        int seat
    )
    {
        Console.WriteLine("tcktBldr: Building full experience ticket with all extras...");
        return Builder
            .SetMovie(movie)
            .SetShowTime(showTime)
            .SetCinemaHall(hall)
            .SetSeat(row, seat)
            .SetVip(true)
            .AddPopcorn()
            .AddDrink()
            .CalculatePrice()
            .Build();
    }

    public Ticket BuildVipTicket(
        string movie,
        DateTime showTime,
        string hall,
        int row,
        int seat
    )
    {
        Console.WriteLine("tcktBldr: Building VIP ticket...");
        return Builder
            .SetMovie(movie)
            .SetShowTime(showTime)
            .SetCinemaHall(hall)
            .SetSeat(row, seat)
            .SetVip(true)
            .CalculatePrice()
            .Build();
    }
}