namespace AbsoluteCinema.PatternExamples.Behavioural.ResponsibilityChain;

public class OperatorResponse : IResChain
{
    IResChain next;
    public void setNext(IResChain next)
    {
        this.next = next;
    }

    public OperatorResponse()
    {
        next = new AdminResponse();
    }

    public string response(string message)
    {
        var response = String.Empty;
        if (!message.StartsWith("Operator"))
        {
            response = next.response(message);
        }
        else
        {
            response = $"Response: {message} replied by : {GetType().Name}";
        }
        return response;
    }
}