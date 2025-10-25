using AbsoluteCinema.PatternExamples.Behavioural.Visitor.Abstraction;
using System.Text;

namespace AbsoluteCinema.PatternExamples.Behavioural.Visitor.Implementation;

public class ReportGenerationVisitor : ICinemaVisitor
{
    private readonly StringBuilder _report = new();
    private int _movieCount;
    private int _subscriptionCount;
    private int _ticketCount;

    public void VisitMovie(MovieElement movie)
    {
        _movieCount++;
        _report.AppendLine($"  Movie: {movie.Movie.Title} ({movie.Movie.Year}) - {movie.Movie.Genre}");
    }

    public void VisitSubscription(SubscriptionElement subscription)
    {
        _subscriptionCount++;
        _report.AppendLine($"  Subscription: {subscription.PlanName} - ${subscription.MonthlyPrice}/month x {subscription.DurationMonths} months");
    }

    public void VisitTicket(TicketElement ticket)
    {
        _ticketCount++;
        _report.AppendLine($"  Ticket: {ticket.HallName} on {ticket.ShowTime:dd/MM/yyyy HH:mm} - ${ticket.Price}");
    }

    public void PrintReport()
    {
        Console.WriteLine("[ReportVisitor] Cinema Elements Report:");
        Console.WriteLine($"  Movies: {_movieCount}");
        Console.WriteLine($"  Subscriptions: {_subscriptionCount}");
        Console.WriteLine($"  Tickets: {_ticketCount}");
        Console.WriteLine("\nDetails:");
        Console.Write(_report.ToString());
    }
}