using AbsoluteCinema.PatternExamples.Creational.Prototype;

namespace AbsoluteCinema.PatternExamples.Creational.FactoryMethod;

public class ChildProfileFactory : IProfileFactory
{
    public Profile CreateProfile()
    {
        return new ChildProfile("Child");
    }
}