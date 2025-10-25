namespace AbsoluteCinema.PatternExamples.Behavioural.Observer.Abstraction;

public interface IMovieObserver
{
    void Update(string eventType, object data);
    string GetIdentifier();
}