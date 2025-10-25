using AbsoluteCinema.PatternExamples.Behavioural.Command.Abstraction;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Command.Implementation;

public class PauseCommand(MediaPlayer player) : ICommand
{
    public void Execute()
    {
        player.Pause();
    }

    public void Undo()
    {
        player.Resume();
    }
}