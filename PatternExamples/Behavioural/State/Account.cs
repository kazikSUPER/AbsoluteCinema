namespace AbsoluteCinema.PatternExamples.Behavioural.State;

public class Account
{
    public IAccountState state = new FreeAccount();

    public void RankUp()
    {
        state = state.RankUp();
    }

    public void Download()
    {
        state.Download();
    }
}