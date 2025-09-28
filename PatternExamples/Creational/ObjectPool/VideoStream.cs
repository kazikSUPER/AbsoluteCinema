namespace AbsoluteCinema.PatternExamples.Creational.ObjectPool;

public class VideoStream
{
    public int StreamId { get; private set; }
    public string UserId { get; set; } = string.Empty;
    public string MovieTitle { get; set; } = string.Empty;
    public string Quality { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime StartTime { get; set; }

    public VideoStream(int streamId)
    {
        StreamId = streamId;
        Console.WriteLine($"VideoStream {streamId} created");
    }

    public void StartStream(
        string movieTitle, 
        string userId, 
        string quality = "1080p"
    )
    {
        Console.WriteLine($"Starting stream {StreamId} for user {userId}");
        Console.WriteLine($"  Movie: {movieTitle}, Quality: {quality}");

        MovieTitle = movieTitle;
        UserId = userId;
        Quality = quality;
        IsActive = true;
        StartTime = DateTime.UtcNow;
    }

    public void StopStream()
    {
        Console.WriteLine($"Stopping stream {StreamId} for user {UserId}");
        Console.WriteLine($"  Movie: {MovieTitle}, Duration: {(StartTime - DateTime.Today).Minutes + Random.Shared.Next(1, 64):F1} minutes");

        Reset();
    }

    public void Reset()
    {
        UserId = string.Empty;
        MovieTitle = string.Empty;
        Quality = string.Empty;
        IsActive = false;
        StartTime = DateTime.UtcNow;
        Console.WriteLine($"VideoStream {StreamId} reset completed.");
    }
}