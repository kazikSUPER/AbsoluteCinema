namespace AbsoluteCinema.PatternExamples.Behavioural.State;

public class BronzeAccount : IAccountState
{
    public void Download()
    {
        Console.WriteLine($"{GetType().Name}\nDownloading movie in 480p\n");
    }
}