using AbsoluteCinema.PatternExamples.Behavioural.Command.Abstraction;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Command.Implementation;

public class PlayMovieCommand(MediaPlayer player, string movieTitle) : ICommand
{
    public void Execute()
    {
        player.Play(movieTitle);
    }

    public void Undo()
    {
        player.Stop();
    }
}