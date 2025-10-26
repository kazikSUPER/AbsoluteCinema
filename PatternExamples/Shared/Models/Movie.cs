using AbsoluteCinema.PatternExamples.Behavioural.Template;
using AbsoluteCinema.PatternExamples.Creational.AbstractFactory;
using AbsoluteCinema.PatternExamples.Creational.StaticFactory;
using AbsoluteCinema.PatternExamples.Shared.Enums;
using AbsoluteCinema.PatternExamples.Structural.FlyWeight;

namespace AbsoluteCinema.PatternExamples.Shared.Models;

public class Movie(string title, int year, string director, GenreType genreType, string format) : IMovie
{
    private readonly IGenreFlyweight _genre = GenreFactory.GetGenre(genreType);
    public string Title => title;
    public IGenreFlyweight Genre => _genre;
    public string Director => director;
    public int Year => year;

    public void Display()
    {
        _genre.DisplayMovieInfo(title, year, director, format);
    }

    public string Format
    {
        get => format;
        set => format = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void Play()
    {
    }

    public void Play(IQualityConverter converter, ISubtitles subtitles)
    {
        converter.Convert();
        subtitles.Subtitles();
        Display();
    }
}