namespace AbsoluteCinema.PatternExamples.Behavioural.Iterator;

public interface IIterator
{
    T Next<T>();
    bool HasNext();
}