using AbsoluteCinema.PatternExamples.Structural.Bridge.Abstraction;

namespace AbsoluteCinema.PatternExamples.Structural.Bridge.Implementation.NotificationType;

public class SubscriptionExpiryNotification(INotificationChannel channel) : NotificationSender(channel)
{
    public override void SendNotification(string message, string recipient)
    {
        string formattedMessage = $"Subscription Alert: {message}";
        Channel.Send(formattedMessage, recipient);
    }
}