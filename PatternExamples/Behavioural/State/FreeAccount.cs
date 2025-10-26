namespace AbsoluteCinema.PatternExamples.Behavioural.State;

public class FreeAccount : IAccountState
{
    public void Download()
    {
        Console.WriteLine($"{GetType().Name}\nSorry, but you can't download from this account.\n");
    }
}