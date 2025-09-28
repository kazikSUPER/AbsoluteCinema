using AbsoluteCinema.PatternExamples.Structural.Bridge.Abstraction;

namespace AbsoluteCinema.PatternExamples.Structural.Bridge.Implementation.Channels;

public class EmailChannel : INotificationChannel
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"Email sent to {recipient}: {message}");
    }
}