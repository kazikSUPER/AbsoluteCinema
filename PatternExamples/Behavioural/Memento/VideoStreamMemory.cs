using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Memento;

public class VideoStreamMemory
{
    int StreamId;
    string UserId { get; set; } = string.Empty;
    string MovieTitle { get; set; } = string.Empty;
    string Quality { get; set; } = string.Empty;
    bool IsActive { get; set; }
    DateTime StartTime { get; set; }

    public VideoStreamMemory(VideoStream videoStream)
    {
        StreamId = videoStream.StreamId;
        UserId = videoStream.UserId;
        MovieTitle = videoStream.MovieTitle;
        Quality = videoStream.Quality;
        IsActive = videoStream.IsActive;
        StartTime = videoStream.StartTime;
    }

    public VideoStream Revise => new VideoStream(StreamId)
    {
        UserId = UserId,
        MovieTitle = MovieTitle,
        Quality = Quality,
        IsActive = IsActive,
        StartTime = StartTime
    };
}