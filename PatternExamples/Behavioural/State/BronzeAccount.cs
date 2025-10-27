namespace AbsoluteCinema.PatternExamples.Behavioural.State;

public class BronzeAccount : IAccountState
{
    public BronzeAccount(IAccountState account)
    {
        
    }
    public void Download()
    {
        Console.WriteLine($"{GetType().Name}\nDownloading movie in 480p\n");
    }

    public IAccountState RankUp()
    {
        return new SilverAccount(this);
    }
}