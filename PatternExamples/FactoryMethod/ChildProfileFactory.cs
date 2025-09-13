using AbsoluteCinema.PatternExamples.Prototype;

namespace AbsoluteCinema.PatternExamples.FactoryMethod;

public class ChildProfileFactory : IProfileFactory
{
    public Profile CreateProfile()
    {
        return new ChildProfile("Child");
    }
}