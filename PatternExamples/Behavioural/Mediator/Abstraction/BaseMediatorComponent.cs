namespace AbsoluteCinema.PatternExamples.Behavioural.Mediator.Abstraction;

public abstract class BaseComponent(ICinemaMediator mediator)
{
    protected readonly ICinemaMediator Mediator = mediator;
}