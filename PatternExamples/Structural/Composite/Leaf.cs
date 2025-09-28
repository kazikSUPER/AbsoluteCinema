using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Structural.Composite;

public class Leaf : IComponent
{
    public Movie movie { get; set; }
    public int Count()
    {
        return 1;
    }
}