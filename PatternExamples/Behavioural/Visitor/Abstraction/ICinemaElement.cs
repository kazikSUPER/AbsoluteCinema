namespace AbsoluteCinema.PatternExamples.Behavioural.Visitor.Abstraction;

public interface ICinemaElement
{
    void Accept(ICinemaVisitor visitor);
}