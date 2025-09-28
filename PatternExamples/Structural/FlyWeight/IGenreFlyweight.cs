namespace AbsoluteCinema.PatternExamples.Structural.FlyWeight;

public interface IGenreFlyweight
{
    void DisplayMovieInfo(string title, int year, string director, string format);
}