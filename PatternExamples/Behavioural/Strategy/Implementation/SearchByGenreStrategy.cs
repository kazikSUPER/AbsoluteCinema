using AbsoluteCinema.PatternExamples.Behavioural.Strategy.Abstraction;
using AbsoluteCinema.PatternExamples.Creational.StaticFactory;
using AbsoluteCinema.PatternExamples.Shared.Enums;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Strategy.Implementation;

public class SearchByGenreStrategy : ISearchStrategy
{
    public List<Movie> Search(List<Movie> movies, string criteria)
    {
        Console.WriteLine($"[SearchByGenre] Searching for movies in genre '{criteria}'");

        if (!Enum.TryParse<GenreType>(criteria, true, out var genre))
        {
            Console.WriteLine($"  Invalid genre: {criteria}");
            return [];
        }

        var results = movies.Where(
            m => GenreFactory.GetGenreType(m.Genre) == genre).ToList();

        foreach (var movie in results)
        {
            Console.WriteLine($"  Found: {movie.Title} ({movie.Genre})");
        }

        return results;
    }

    public string GetStrategyName() => "Search by Genre";
}