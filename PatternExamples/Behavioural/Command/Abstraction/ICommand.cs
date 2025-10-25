namespace AbsoluteCinema.PatternExamples.Behavioural.Command.Abstraction;

public interface ICommand
{
    void Execute();
    void Undo();
}