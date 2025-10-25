using AbsoluteCinema.PatternExamples.Behavioural.Command.Abstraction;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Command.Implementation;

public class StopCommand(MediaPlayer player) : ICommand
{
    public void Execute()
    {
        player.Stop();
    }

    public void Undo()
    {
        Console.WriteLine("[Command] Cannot undo stop operation");
    }
}