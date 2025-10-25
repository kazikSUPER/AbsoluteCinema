using AbsoluteCinema.PatternExamples.Behavioural.Observer.Abstraction;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Observer.Implementation;

public class MovieReleaseTracker : IMovieSubject
{
    private readonly List<IMovieObserver> _observers = [];
    private readonly List<MovieRelease> _upcomingMovies = [];


    public void Attach(IMovieObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
            Console.WriteLine($"[MovieTracker] Observer attached: {observer.GetIdentifier()}");
        }
    }

    public void Detach(IMovieObserver observer)
    {
        if (_observers.Remove(observer))
        {
            Console.WriteLine($"[MovieTracker] Observer detached: {observer.GetIdentifier()}");
        }
    }

    public void NotifyObservers(string eventType, object data)
    {
        Console.WriteLine($"[MovieTracker] Notifying {_observers.Count} observers about: {eventType}");

        foreach (var observer in _observers)
        {
            observer.Update(eventType, data);
        }
    }

    public void AnnounceNewMovie(string title, DateTime releaseDate)
    {
        var movie = new MovieRelease
        {
            Title = title,
            ReleaseDate = releaseDate
        };

        _upcomingMovies.Add(movie);
        Console.WriteLine($"\n[MovieTracker] New movie announced: '{title}' releasing on {releaseDate:dd/MM/yyyy}");

        NotifyObservers("NewMovieRelease", movie);
    }


    public void AnnouncePriceChange(string subscriptionType, decimal newPrice)
    {
        var priceChange = new PriceChangeInfo
        {
            SubscriptionType = subscriptionType,
            NewPrice = newPrice
        };

        Console.WriteLine($"\n[MovieTracker] Price change: {subscriptionType} subscription now ${newPrice}");

        NotifyObservers("PriceChange", priceChange);
    }


    public void AnnounceSpecialScreening(string movieTitle, DateTime screeningDate)
    {
        var screening = new SpecialScreening
        {
            MovieTitle = movieTitle,
            ScreeningDate = screeningDate
        };

        Console.WriteLine($"\n[MovieTracker] Special screening: '{movieTitle}' on {screeningDate:dd/MM/yyyy HH:mm}");

        NotifyObservers("SpecialScreening", screening);
    }
}