namespace AbsoluteCinema.PatternExamples.Structural.Proxy;

public interface IMovieDatabase
{
    string GetMovieDetails(string movieId);
    List<string> GetMovieReviews(string movieId);
    void UpdateMovieRating(string movieId, double rating);
}