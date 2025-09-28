namespace AbsoluteCinema.PatternExamples.Creational.Builder;

public interface ITicketBuilder
{
    ITicketBuilder SetMovie(string movieTitle);
    ITicketBuilder SetShowTime(DateTime showTime);
    ITicketBuilder SetCinemaHall(string hall);
    ITicketBuilder SetSeat(int row, int number);
    ITicketBuilder SetVip(bool isVip);
    ITicketBuilder AddPopcorn();
    ITicketBuilder AddDrink();
    ITicketBuilder CalculatePrice();
    Ticket Build();
    void Reset();
}