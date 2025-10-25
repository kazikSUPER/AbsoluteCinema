using AbsoluteCinema.PatternExamples.Shared.Enums;
using AbsoluteCinema.PatternExamples.Structural.FlyWeight;

namespace AbsoluteCinema.PatternExamples.Creational.StaticFactory;

public class GenreFactory
{
    private static readonly Dictionary<GenreType, IGenreFlyweight> Genres = new();

    public static IGenreFlyweight GetGenre(GenreType genreType)
    {
        if (!Genres.ContainsKey(genreType))
        {
            Genres[genreType] = genreType switch
            {
                GenreType.Action => new GenreFlyweight("Action", "High-energy films with intense sequences"),
                GenreType.Comedy => new GenreFlyweight("Comedy", "Films designed to make audiences laugh"),
                GenreType.Drama => new GenreFlyweight("Drama", "Serious narrative films with emotional themes"),
                GenreType.Horror => new GenreFlyweight("Horror", "Films intended to frighten and create suspense"),
                GenreType.SciFi => new GenreFlyweight("Sci-Fi", "Science fiction films exploring futuristic concepts"),
                GenreType.Romance => new GenreFlyweight("Romance", "Films focusing on love stories and relationships"),
                GenreType.Thriller => new GenreFlyweight("Thriller", "Suspenseful films that keep audiences on edge"),
                _ => new GenreFlyweight("Unknown", "Uncategorized genre")
            };
        }

        return Genres[genreType];
    }

    public static GenreType GetGenreType(IGenreFlyweight genre)
    {
        return Genres.FirstOrDefault(g => g.Value == genre).Key;
    }

    public static int GetCreatedGenresCount()
    {
        return Genres.Count;
    }
}