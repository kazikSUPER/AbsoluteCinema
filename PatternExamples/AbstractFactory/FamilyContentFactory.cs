using AbsoluteCinema.PatternExamples.Prototype;

namespace AbsoluteCinema.PatternExamples.AbstractFactory;

public class FamilyContentFactory : IMovieFactory
{
    public IMovie CreateMovie()
    {
        return new FamilyMovie();
    }

    public ISubscription CreateSubscription()
    {
        return new FamilySubscription();
    }

    public Profile CreateViewerProfile()
    {
        return new FamilyProfile("FamilyViewer");
    }
}