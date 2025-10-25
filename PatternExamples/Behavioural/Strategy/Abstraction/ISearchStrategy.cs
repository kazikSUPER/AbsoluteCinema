using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Strategy.Abstraction;

public interface ISearchStrategy
{
    List<Movie> Search(List<Movie> movies, string criteria);
    string GetStrategyName();
}