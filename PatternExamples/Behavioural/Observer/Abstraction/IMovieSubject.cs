namespace AbsoluteCinema.PatternExamples.Behavioural.Observer.Abstraction;

public interface IMovieSubject
{
    void Attach(IMovieObserver observer);
    void Detach(IMovieObserver observer);
    void NotifyObservers(string eventType, object data);
}