namespace AbsoluteCinema.PatternExamples.Structural.Proxy;

public class MovieDatabaseProxy : IMovieDatabase
{
    private RemoteMovieDatabase? _remoteDatabase;
    private readonly Dictionary<string, string> _movieDetailsCache = new();
    private readonly Dictionary<string, List<string>> _reviewsCache = new();

    public string GetMovieDetails(string movieId)
    {
        if (_movieDetailsCache.TryGetValue(movieId, out var movieDetails))
        {
            Console.WriteLine($"Returning cached movie details for ID: {movieId}");
            return movieDetails;
        }

        _remoteDatabase ??= new RemoteMovieDatabase();

        var details = _remoteDatabase.GetMovieDetails(movieId);
        _movieDetailsCache[movieId] = details;
        return details;
    }

    public List<string> GetMovieReviews(string movieId)
    {
        if (_reviewsCache.TryGetValue(movieId, out var movieReviews))
        {
            Console.WriteLine($"Returning cached reviews for movie ID: {movieId}");
            return movieReviews;
        }

        _remoteDatabase ??= new RemoteMovieDatabase();

        var reviews = _remoteDatabase.GetMovieReviews(movieId);
        _reviewsCache[movieId] = reviews;
        return reviews;
    }

    public void UpdateMovieRating(string movieId, double rating)
    {
        _remoteDatabase ??= new RemoteMovieDatabase();

        _remoteDatabase.UpdateMovieRating(movieId, rating);

        if (_movieDetailsCache.ContainsKey(movieId))
        {
            Console.WriteLine($"Removing old movie {movieId} from 'cache'");
            _movieDetailsCache.Remove(movieId);
        }
    }
}