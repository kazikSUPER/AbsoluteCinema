namespace AbsoluteCinema.PatternExamples.Behavioural.State;

public class SilverAccount : IAccountState
{
    public SilverAccount(IAccountState account)
    {
        
    }
    public void Download()
    {
        Console.WriteLine($"{GetType().Name}\nChoose quality:\n480p\n720p\n");
    }

    public IAccountState RankUp()
    {
        return new GoldAccount(this);
    }
}