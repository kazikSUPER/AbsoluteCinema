namespace AbsoluteCinema.PatternExamples.AbstractFactory;

public interface ISubscription
{
    string GetPlanName();
    decimal GetPrice();
    int GetMaxQuality();
    void Activate();
}