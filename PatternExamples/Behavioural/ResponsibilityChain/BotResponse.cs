namespace AbsoluteCinema.PatternExamples.Behavioural.ResponsibilityChain;

public class BotResponse : IResChain
{
    IResChain next;
    public void setNext(IResChain next)
    {
        this.next = next;
    }

    public BotResponse()
    {
        next = new OperatorResponse();
    }

    public string response(string message)
    {
        var response = String.Empty;
        if (!message.StartsWith("Bot"))
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