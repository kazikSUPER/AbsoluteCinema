using AbsoluteCinema.PatternExamples.Behavioural.Mediator.Abstraction;

namespace AbsoluteCinema.PatternExamples.Behavioural.Mediator.Implementation;

public class PaymentSystem(ICinemaMediator mediator) : BaseComponent(mediator)
{
    public void ProcessPayment(string userName, decimal amount)
    {
        Console.WriteLine($"[PaymentSystem] Processing payment of ${amount:F2} for {userName}");

        bool success = amount > 0; 

        if (success)
        {
            Console.WriteLine($"[PaymentSystem] Payment successful: ${amount:F2}");
            Mediator.Notify(this, "PaymentProcessed", userName);
        }
        else
        {
            Console.WriteLine("[PaymentSystem] Payment failed");
            Mediator.Notify(this, "PaymentFailed", userName);
        }
    }

    public void RefundPayment(string userName, decimal amount)
    {
        Console.WriteLine($"[PaymentSystem] Refunding ${amount:F2} to {userName}");
    }
}