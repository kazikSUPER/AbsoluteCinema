using AbsoluteCinema.PatternExamples.Behavioural.Template;

namespace AbsoluteCinema.PatternExamples.Creational.AbstractFactory;

public interface IMovie
{
    //string GetTitle();
    //string GetGenre();
    //int GetAgeRating();
    void Play(IQualityConverter converter, ISubtitles subtitles);
    void Play();
}
