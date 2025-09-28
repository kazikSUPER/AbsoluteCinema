namespace AbsoluteCinema.PatternExamples.Creational.AbstractFactory;

public interface ISubscription
{
    string GetPlanName();
    decimal GetPrice();
    int GetMaxQuality();
    void Activate();
}