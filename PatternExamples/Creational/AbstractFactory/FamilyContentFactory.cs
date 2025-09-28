using AbsoluteCinema.PatternExamples.Creational.Prototype;

namespace AbsoluteCinema.PatternExamples.Creational.AbstractFactory;

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