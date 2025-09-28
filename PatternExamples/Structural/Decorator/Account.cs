namespace AbsoluteCinema.PatternExamples.Structural.Decorator;

public class Account : IAccount
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string GetAccount()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}