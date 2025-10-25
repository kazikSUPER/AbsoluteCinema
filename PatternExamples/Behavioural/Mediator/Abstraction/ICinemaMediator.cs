namespace AbsoluteCinema.PatternExamples.Behavioural.Mediator.Abstraction;

public interface ICinemaMediator
{
    void Notify(object sender, string eventType, object? data = null);
}
