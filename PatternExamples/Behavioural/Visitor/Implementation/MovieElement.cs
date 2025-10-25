using AbsoluteCinema.PatternExamples.Behavioural.Visitor.Abstraction;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Visitor.Implementation;

public class MovieElement(Movie movie) : ICinemaElement
{
    public Movie Movie { get; } = movie;

    public void Accept(ICinemaVisitor visitor)
    {
        visitor.VisitMovie(this);
    }
}