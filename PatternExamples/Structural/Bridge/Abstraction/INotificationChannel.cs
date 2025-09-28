namespace AbsoluteCinema.PatternExamples.Structural.Bridge.Abstraction;

public interface INotificationChannel
{
    void Send(string message, string recipient);
}