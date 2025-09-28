using AbsoluteCinema.PatternExamples.Structural.Bridge.Abstraction;

namespace AbsoluteCinema.PatternExamples.Structural.Bridge.Implementation.NotificationType;

public class RecommendationNotification(INotificationChannel channel) : NotificationSender(channel)
{
    public override void SendNotification(string message, string recipient)
    {
        string formattedMessage = $"Recommended for you: {message}";
        Channel.Send(formattedMessage, recipient);
    }
}