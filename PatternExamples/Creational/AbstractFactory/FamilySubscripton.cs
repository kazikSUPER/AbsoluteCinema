namespace AbsoluteCinema.PatternExamples.Creational.AbstractFactory;

public class FamilySubscription : ISubscription
{
    private string _planName = "Family Plan";
    private decimal _price = 14.99m;
    private int _maxQuality = 8640;

    public string GetPlanName() => _planName;
    public decimal GetPrice() => _price;
    public int GetMaxQuality() => _maxQuality;

    public void Activate()
    {
        Console.WriteLine($"Activating {_planName}: ${_price}/month, Max Quality: {_maxQuality}p");
    }
}