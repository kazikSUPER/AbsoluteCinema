using AbsoluteCinema.PatternExamples.Creational.Prototype;

namespace AbsoluteCinema.PatternExamples.Creational.AbstractFactory;

public interface IMovieFactory
{
    IMovie CreateMovie();
    ISubscription CreateSubscription();
    Profile CreateViewerProfile();
}