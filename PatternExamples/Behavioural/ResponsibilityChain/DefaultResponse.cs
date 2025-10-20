namespace AbsoluteCinema.PatternExamples.Behavioural.ResponsibilityChain;

public class DefaultResponse : IResChain
{
    IResChain next;
    public void setNext(IResChain next)
    {
        this.next = next;
    }

    public string response(string message)
    {
        return $"Response: {message} replied by : {GetType().Name}";
    }
}