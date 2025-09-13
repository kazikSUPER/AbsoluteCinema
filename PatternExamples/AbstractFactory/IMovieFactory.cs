using AbsoluteCinema.PatternExamples.Prototype;

namespace AbsoluteCinema.PatternExamples.AbstractFactory;

public interface IMovieFactory
{
    IMovie CreateMovie();
    ISubscription CreateSubscription();
    Profile CreateViewerProfile();
}