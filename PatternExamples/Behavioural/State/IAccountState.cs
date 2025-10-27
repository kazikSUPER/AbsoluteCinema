namespace AbsoluteCinema.PatternExamples.Behavioural.State;

public interface IAccountState
{
    void Download();
    IAccountState RankUp();
}