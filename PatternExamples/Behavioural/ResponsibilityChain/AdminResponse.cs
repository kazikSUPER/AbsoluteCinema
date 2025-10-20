namespace AbsoluteCinema.PatternExamples.Behavioural.ResponsibilityChain;

public class AdminResponse : IResChain
{
    IResChain next;
    public void setNext(IResChain next)
    {
        this.next = next;
    }

    public AdminResponse()
    {
        next = new DefaultResponse();
    }

    public string response(string message)
    {
        var response = String.Empty;
        if (!message.StartsWith("Admin"))
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