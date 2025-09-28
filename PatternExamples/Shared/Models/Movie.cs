using AbsoluteCinema.PatternExamples.Creational.AbstractFactory;
using AbsoluteCinema.PatternExamples.Creational.StaticFactory;
using AbsoluteCinema.PatternExamples.Shared.Enums;
using AbsoluteCinema.PatternExamples.Structural.FlyWeight;

namespace AbsoluteCinema.PatternExamples.Shared.Models;

public class Movie(string title, int year, string director, GenreType genreType) : IMovie
{
    private readonly IGenreFlyweight _genre = GenreFactory.GetGenre(genreType);

    public void Display()
    {
        _genre.DisplayMovieInfo(title, year, director);
    }

    public void Play()
    {
    }
}