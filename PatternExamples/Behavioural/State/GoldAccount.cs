namespace AbsoluteCinema.PatternExamples.Behavioural.State;

public class GoldAccount : IAccountState
{
    public void Download()
    {
        Console.WriteLine($"{GetType().Name}\nChoose quality:\n480p\n720p\n1080p\n");
    }
}