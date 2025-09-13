namespace AbsoluteCinema.PatternExamples.AbstractFactory;

public interface IMovie
{
    string GetTitle();
    string GetGenre();
    int GetAgeRating();
    void Play();
}
