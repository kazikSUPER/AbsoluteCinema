using AbsoluteCinema.PatternExamples.Creational.Prototype;

namespace AbsoluteCinema.PatternExamples.Creational.FactoryMethod;

public class AdultProfileFactory : IProfileFactory
{
    public Profile CreateProfile()
    {
        return new AdultProfile("Adult");
    }
}