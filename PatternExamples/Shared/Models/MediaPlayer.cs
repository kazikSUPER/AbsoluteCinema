namespace AbsoluteCinema.PatternExamples.Shared.Models;

public class MediaPlayer
{
    private string _currentMovie = "";

    public bool IsPlaying { get; private set; }
    public bool IsPaused { get; private set; }
    public int Volume { get; private set; } = 50;

    public void Play(string movieTitle)
    {
        Console.WriteLine($"[MediaPlayer] Starting playback: '{movieTitle}'");
        _currentMovie = movieTitle;
        IsPlaying = true;
        IsPaused = false;
    }

    public void Pause()
    {
        if (IsPlaying && !IsPaused)
        {
            Console.WriteLine($"[MediaPlayer] Pausing: '{_currentMovie}'");
            IsPaused = true;
        }
        else
        {
            Console.WriteLine("[MediaPlayer] Nothing to pause");
        }
    }

   
    public void Resume()
    {
        if (IsPaused)
        {
            Console.WriteLine($"[MediaPlayer] Resuming: '{_currentMovie}'");
            IsPaused = false;
        }
        else
        {
            Console.WriteLine("[MediaPlayer] Nothing to resume");
        }
    }

 
    public void Stop()
    {
        if (IsPlaying)
        {
            Console.WriteLine($"[MediaPlayer] Stopping playback: '{_currentMovie}'");
            IsPlaying = false;
            IsPaused = false;
            _currentMovie = "";
        }
        else
        {
            Console.WriteLine("[MediaPlayer] Nothing to stop");
        }
    }
}