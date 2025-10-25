using AbsoluteCinema.PatternExamples.Behavioural.Strategy.Abstraction;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Strategy.Implementation;

public class MovieSearchContext
{
    private ISearchStrategy? _strategy;

    public void SetStrategy(ISearchStrategy strategy)
    {
        _strategy = strategy;
        Console.WriteLine($"Search strategy set to: {strategy.GetStrategyName()}");
    }

    public List<Movie> Search(List<Movie> movies, string criteria)
    {
        if (_strategy == null)
        {
            throw new InvalidOperationException("Search strategy not set");
        }

        return _strategy.Search(movies, criteria);
    }
}