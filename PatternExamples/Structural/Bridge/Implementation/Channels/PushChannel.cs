using AbsoluteCinema.PatternExamples.Structural.Bridge.Abstraction;

namespace AbsoluteCinema.PatternExamples.Structural.Bridge.Implementation.Channels;

public class PushChannel : INotificationChannel
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"Push notification sent to {recipient}: {message}");
    }
}