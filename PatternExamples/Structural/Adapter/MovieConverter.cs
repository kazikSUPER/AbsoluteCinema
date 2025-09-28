using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Structural.Adapter;

public class MovieConverter
{
    public static Movie ConvertMovieToMp4(Movie movie)
    {
        Console.WriteLine($"Convert {movie.Format} To MP4\n");
        switch (movie.Format)
        {
            case "MKV":
            {
                ConvertMkvToMp4(movie);
                break;
            }
            case "AVI":
            {
                ConvertAviToMp4(movie);
                break;
            }
            case "MP4":
            {
                Console.WriteLine("No conversion required\n");
                return movie;
            }
            default:
            {
                Console.WriteLine($"Unsupported format: {movie.Format}\n");
                return null;
            }
        }
        Console.WriteLine("Video conversion complete.\n");
        return movie;
    }

    private static Movie ConvertMkvToMp4(Movie movie)
    {
        movie.Format = "MP4";
        Task.Delay(1000).Wait();
        return movie;
    }

    private static Movie ConvertAviToMp4(Movie movie)
    {
        movie.Format = "MKV";
        Task.Delay(1000).Wait();
        ConvertMkvToMp4(movie);
        return movie;
    }
}