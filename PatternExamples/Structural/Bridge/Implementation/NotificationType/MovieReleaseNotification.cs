using AbsoluteCinema.PatternExamples.Structural.Bridge.Abstraction;

namespace AbsoluteCinema.PatternExamples.Structural.Bridge.Implementation.NotificationType;

public class MovieReleaseNotification(INotificationChannel channel) : NotificationSender(channel)
{
    public override void SendNotification(string message, string recipient)
    {
        string formattedMessage = $"New Movie Release: {message}";
        Channel.Send(formattedMessage, recipient);
    }
}