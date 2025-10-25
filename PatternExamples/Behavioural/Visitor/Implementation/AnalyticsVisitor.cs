using AbsoluteCinema.PatternExamples.Behavioural.Visitor.Abstraction;
using AbsoluteCinema.PatternExamples.Creational.StaticFactory;

namespace AbsoluteCinema.PatternExamples.Behavioural.Visitor.Implementation;

public class AnalyticsVisitor : ICinemaVisitor
{
    private int _totalMovies;
    private int _totalSubscriptions;
    private int _totalTickets;
    private decimal _totalRevenue;
    private readonly Dictionary<string, int> _genreCounts = new();
    private readonly Dictionary<string, int> _hallCounts = new();

    public void VisitMovie(MovieElement movie)
    {
        _totalMovies++;

        string genre = GenreFactory.GetGenreType(movie.Movie.Genre).ToString();
        if (!_genreCounts.TryAdd(genre, 1))
        {
            _genreCounts[genre]++;
        }
    }

    public void VisitSubscription(SubscriptionElement subscription)
    {
        _totalSubscriptions++;
        _totalRevenue += subscription.GetTotalPrice();
    }

    public void VisitTicket(TicketElement ticket)
    {
        _totalTickets++;
        _totalRevenue += ticket.Price;

        if (!_hallCounts.TryAdd(ticket.HallName, 1))
            _hallCounts[ticket.HallName]++;
    }

    public void PrintStatistics()
    {
        Console.WriteLine("[AnalyticsVisitor] Cinema Statistics:");
        Console.WriteLine($"  Total Movies: {_totalMovies}");
        Console.WriteLine($"  Total Subscriptions: {_totalSubscriptions}");
        Console.WriteLine($"  Total Tickets: {_totalTickets}");
        Console.WriteLine($"  Total Revenue: ${_totalRevenue:F2}");

        if (_genreCounts.Count > 0)
        {
            Console.WriteLine("\n  Genre Distribution:");
            foreach (var kvp in _genreCounts)
            {
                Console.WriteLine($"    {kvp.Key}: {kvp.Value}");
            }
        }

        if (_hallCounts.Count > 0)
        {
            Console.WriteLine("\n  Hall Utilization:");
            foreach (var kvp in _hallCounts)
            {
                Console.WriteLine($"    {kvp.Key}: {kvp.Value} tickets");
            }
        }
    }
}