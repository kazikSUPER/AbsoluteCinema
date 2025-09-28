namespace AbsoluteCinema.PatternExamples.Structural.FlyWeight;

public class GenreFlyweight(string name, string description) : IGenreFlyweight
{
    public void DisplayMovieInfo(string title, int year, string director)
    {
        Console.WriteLine($"[{name}] {title} ({year}) - Directed by {director}");
        Console.WriteLine($"Genre: {description}");
    }
}