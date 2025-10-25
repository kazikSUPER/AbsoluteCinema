using AbsoluteCinema.PatternExamples.Behavioural.Command.Abstraction;

namespace AbsoluteCinema.PatternExamples.Behavioural.Command.Implementation.Helpers;

public class CommandInvoker
{
    private ICommand? _currentCommand;
    private readonly Stack<ICommand> _commandHistory = new();

    public void SetCommand(ICommand command)
    {
        _currentCommand = command;
    }

    public void Invoke()
    {
        if (_currentCommand != null)
        {
            _currentCommand.Execute();
            _commandHistory.Push(_currentCommand);
        }
        else
        {
            Console.WriteLine("[RemoteControl] No command set");
        }
    }

    public void Undo()
    {
        if (_commandHistory.Count > 0)
        {
            var lastCommand = _commandHistory.Pop();
            lastCommand.Undo();
        }
        else
        {
            Console.WriteLine("[RemoteControl] No commands to undo");
        }
    }
}