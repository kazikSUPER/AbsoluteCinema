using AbsoluteCinema.PatternExamples.Structural.Bridge.Abstraction;

namespace AbsoluteCinema.PatternExamples.Structural.Bridge.Implementation.Channels;

public class SmsChannel : INotificationChannel
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"SMS sent to {recipient}: {message}");
    }
}