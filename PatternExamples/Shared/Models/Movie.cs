using AbsoluteCinema.PatternExamples.Behavioural.Memento;
using AbsoluteCinema.PatternExamples.Behavioural.Template;
using AbsoluteCinema.PatternExamples.Creational.AbstractFactory;
using AbsoluteCinema.PatternExamples.Creational.StaticFactory;
using AbsoluteCinema.PatternExamples.Shared.Enums;
using AbsoluteCinema.PatternExamples.Structural.FlyWeight;

namespace AbsoluteCinema.PatternExamples.Shared.Models;

public class Movie(string title, int year, string director, GenreType genreType, string format) : IMovie
{
    private readonly IGenreFlyweight _genre = GenreFactory.GetGenre(genreType);
    
    public string Title { get => title; set  => title = value; }

    public void Display()
    {
        _genre.DisplayMovieInfo(title, year, director, format);
    }

    public string Format
    {
        get => format;
        set => format = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void Play(IQualityConverter converter, ISubtitles subtitles)
    {
        converter.Convert();
        subtitles.Subtitles();
        Display();
    }

    public void Play(){}
}