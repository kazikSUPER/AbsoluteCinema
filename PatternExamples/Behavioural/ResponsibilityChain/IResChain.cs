namespace AbsoluteCinema.PatternExamples.Behavioural.ResponsibilityChain;

public interface IResChain
{
    void setNext(IResChain next);
    string response(string message);
}