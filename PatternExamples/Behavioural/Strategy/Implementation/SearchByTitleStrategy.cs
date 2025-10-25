using AbsoluteCinema.PatternExamples.Behavioural.Strategy.Abstraction;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Strategy.Implementation;

public class SearchByTitleStrategy : ISearchStrategy
{
    public List<Movie> Search(List<Movie> movies, string criteria)
    {
        Console.WriteLine($"[SearchByTitle] Searching for movies with title containing '{criteria}'");

        var results = movies
            .Where(m => m.Title.Contains(criteria, StringComparison.OrdinalIgnoreCase))
            .ToList();

        foreach (var movie in results)
        {
            Console.WriteLine($"  Found: {movie.Title} ({movie.Year}) Director: {movie.Director}");
        }

        return results;
    }

    public string GetStrategyName() => "Search by Title";
}