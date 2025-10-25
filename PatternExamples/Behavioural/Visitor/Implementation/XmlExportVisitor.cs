using AbsoluteCinema.PatternExamples.Behavioural.Visitor.Abstraction;
using System.Text;

namespace AbsoluteCinema.PatternExamples.Behavioural.Visitor.Implementation;

public class XmlExportVisitor : ICinemaVisitor
{
    private readonly StringBuilder _xml = new();

    public XmlExportVisitor()
    {
        _xml.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        _xml.AppendLine("<CinemaData>");
    }

    public void VisitMovie(MovieElement movie)
    {
        _xml.AppendLine("  <Movie>");
        _xml.AppendLine($"    <Title>{movie.Movie.Title}</Title>");
        _xml.AppendLine($"    <Year>{movie.Movie.Year}</Year>");
        _xml.AppendLine($"    <Director>{movie.Movie.Director}</Director>");
        _xml.AppendLine($"    <Genre>{movie.Movie.Genre}</Genre>");
        _xml.AppendLine($"    <Format>{movie.Movie.Format}</Format>");
        _xml.AppendLine("  </Movie>");
    }

    public void VisitSubscription(SubscriptionElement subscription)
    {
        _xml.AppendLine("  <Subscription>");
        _xml.AppendLine($"    <PlanName>{subscription.PlanName}</PlanName>");
        _xml.AppendLine($"    <MonthlyPrice>{subscription.MonthlyPrice}</MonthlyPrice>");
        _xml.AppendLine($"    <DurationMonths>{subscription.DurationMonths}</DurationMonths>");
        _xml.AppendLine($"    <TotalPrice>{subscription.GetTotalPrice()}</TotalPrice>");
        _xml.AppendLine("  </Subscription>");
    }

    public void VisitTicket(TicketElement ticket)
    {
        _xml.AppendLine("  <Ticket>");
        _xml.AppendLine($"    <HallName>{ticket.HallName}</HallName>");
        _xml.AppendLine($"    <ShowTime>{ticket.ShowTime:yyyy-MM-ddTHH:mm:ss}</ShowTime>");
        _xml.AppendLine($"    <Price>{ticket.Price}</Price>");
        _xml.AppendLine("  </Ticket>");
    }

    public string GetXml()
    {
        var result = new StringBuilder(_xml.ToString());
        result.AppendLine("</CinemaData>");
        return result.ToString();
    }
}