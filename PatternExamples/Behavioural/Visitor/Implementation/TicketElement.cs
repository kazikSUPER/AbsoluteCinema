using AbsoluteCinema.PatternExamples.Behavioural.Visitor.Abstraction;

namespace AbsoluteCinema.PatternExamples.Behavioural.Visitor.Implementation;

public class TicketElement(string hallName, DateTime showTime, decimal price) : ICinemaElement
{
    public string HallName { get; } = hallName;
    public DateTime ShowTime { get; } = showTime;
    public decimal Price { get; set; } = price;

    public void Accept(ICinemaVisitor visitor)
    {
        visitor.VisitTicket(this);
    }
}