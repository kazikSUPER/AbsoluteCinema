namespace AbsoluteCinema.PatternExamples.Structural.Proxy;

public class RemoteMovieDatabase : IMovieDatabase
{
    public string GetMovieDetails(string movieId)
    {
        Console.WriteLine($"Fetching movie details from remote server for ID: {movieId}");
        Thread.Sleep(2000);
        return $"Movie Details for {movieId}: Title, Director, Cast, Plot...";
    }

    public List<string> GetMovieReviews(string movieId)
    {
        Console.WriteLine($"Fetching reviews from remote server for movie ID: {movieId}");
        Thread.Sleep(1500);
        return ["Great movie!", "Amazing visuals", "Must watch"];
    }

    public void UpdateMovieRating(string movieId, double rating)
    {
        Console.WriteLine($"Updating rating on remote server for movie {movieId}: {rating}/10");
        Thread.Sleep(1000);
    }
}