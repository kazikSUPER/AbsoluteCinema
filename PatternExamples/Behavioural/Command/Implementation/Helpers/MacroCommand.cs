using AbsoluteCinema.PatternExamples.Behavioural.Command.Abstraction;

namespace AbsoluteCinema.PatternExamples.Behavioural.Command.Implementation.Helpers;

public class MacroCommand(ICommand[] commands) : ICommand
{
    public void Execute()
    {
        Console.WriteLine("[MacroCommand] Executing multiple commands...");
        foreach (var command in commands)
        {
            command.Execute();
        }
    }

    public void Undo()
    {
        Console.WriteLine("[MacroCommand] Undoing multiple commands...");
        for (int i = commands.Length - 1; i >= 0; i--)
        {
            commands[i].Undo();
        }
    }
}