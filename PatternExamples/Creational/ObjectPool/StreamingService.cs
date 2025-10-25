using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Creational.ObjectPool;

public class StreamingService
{
    private readonly VideoStreamPool _streamPool;
    private readonly Dictionary<string, VideoStream> _userStreams = new();

    public StreamingService(VideoStreamPool pool)
    {
        _streamPool = pool;
        Console.WriteLine("StreamingService initialized");
    }

    public bool StartMovieForUser(string userId, Movie movie, string quality = "1080p")
    {
        Console.WriteLine($"\n[StreamingService] User {userId} requesting to watch '{movie.Title}'");

        if (_userStreams.ContainsKey(userId))
        {
            Console.WriteLine($"User {userId} already has an active stream!");
            return false;
        }

        VideoStream stream = _streamPool.AcquireStream();

        if (stream == null)
        {
            Console.WriteLine($"No streams available for user {userId}. Please try again later.");
            return false;
        }

        stream.StartStream(movie, userId, quality);
        _userStreams[userId] = stream;

        Console.WriteLine($"Stream ready for user {userId}!");
        return true;
    }

    public void StopMovieForUser(string userId)
    {
        Console.WriteLine($"\n[StreamingService] Stopping stream for user {userId}");

        if (!_userStreams.TryGetValue(userId, out var stream))
        {
            Console.WriteLine($"No active stream found for user {userId}");
            return;
        }

        stream.StopStream();
        _streamPool.ReleaseStream(stream);
        _userStreams.Remove(userId);

        Console.WriteLine($"Stream stopped and released for user {userId}");
    }

    public void ShowActiveUsers()
    {
        Console.WriteLine("\n=== Active Users ===");
        if (_userStreams.Count == 0)
        {
            Console.WriteLine("No active users");
        }
        else
        {
            foreach (var kvp in _userStreams)
            {
                Console.WriteLine($"User: {kvp.Key}, Movie: {kvp.Value.MovieTitle}, Quality: {kvp.Value.Quality}");
            }
        }
        Console.WriteLine("===================\n");
    }
}