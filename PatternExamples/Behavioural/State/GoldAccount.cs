namespace AbsoluteCinema.PatternExamples.Behavioural.State;

public class GoldAccount : IAccountState
{
    public GoldAccount(IAccountState account)
    {
        
    }
    public void Download()
    {
        Console.WriteLine($"{GetType().Name}\nChoose quality:\n480p\n720p\n1080p\n");
    }

    public IAccountState RankUp()
    {
        return new PlatinumAccount(this);
    }
}