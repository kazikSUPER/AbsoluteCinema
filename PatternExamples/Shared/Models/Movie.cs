using AbsoluteCinema.PatternExamples.Creational.AbstractFactory;
using AbsoluteCinema.PatternExamples.Creational.StaticFactory;
using AbsoluteCinema.PatternExamples.Shared.Enums;
using AbsoluteCinema.PatternExamples.Structural.FlyWeight;

namespace AbsoluteCinema.PatternExamples.Shared.Models;

public class Movie(string title, int year, string director, GenreType genreType, string format) : IMovie
{
    private string _format = format;

    public string Title => title;
    public int Year => year;
    public string Director => director;
    public IGenreFlyweight Genre { get; } = GenreFactory.GetGenre(genreType);

    public string Format
    {
        get => _format;
        set => _format = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void Display()
    {
        Genre.DisplayMovieInfo(title, year, director, _format);
    }

    public void Play()
    {
    }
}