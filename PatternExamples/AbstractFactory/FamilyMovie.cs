namespace AbsoluteCinema.PatternExamples.AbstractFactory;

public class FamilyMovie : IMovie
{
    private string _title = "Up";
    private string _genre = "Animation";
    private int _ageRating = 0;

    public string GetTitle() => _title;
    public string GetGenre() => _genre;
    public int GetAgeRating() => _ageRating;

    public void Play()
    {
        Console.WriteLine($"Playing family movie: {_title}, Genre: {_genre}, Age Rating: {_ageRating}+");
    }
}