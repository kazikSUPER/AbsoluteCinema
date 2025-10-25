using AbsoluteCinema.PatternExamples.Behavioural.Visitor.Abstraction;

namespace AbsoluteCinema.PatternExamples.Behavioural.Visitor.Implementation;

public class SubscriptionElement(string planName, decimal monthlyPrice, int durationMonths) : ICinemaElement
{
    public string PlanName { get; } = planName;
    public decimal MonthlyPrice { get; } = monthlyPrice;
    public int DurationMonths { get; } = durationMonths;

    public void Accept(ICinemaVisitor visitor)
    {
        visitor.VisitSubscription(this);
    }

    public decimal GetTotalPrice() => MonthlyPrice * DurationMonths;
}