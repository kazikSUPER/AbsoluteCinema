using AbsoluteCinema.PatternExamples.Behavioural.Mediator.Abstraction;

namespace AbsoluteCinema.PatternExamples.Behavioural.Mediator.Implementation;

public class NotificationService(ICinemaMediator mediator) : BaseComponent(mediator)
{
    public void SendNotification(string userName, string message)
    {
        Console.WriteLine($"[NotificationService] Sending to {userName}: {message}");
    }
}