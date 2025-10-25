namespace AbsoluteCinema.PatternExamples.Structural.Bridge.Abstraction;

public abstract class NotificationSender(INotificationChannel channel)
{
    protected readonly INotificationChannel Channel = channel;

    public abstract void SendNotification(string message, string recipient);
}