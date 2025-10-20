using System.Data.SqlTypes;

namespace AbsoluteCinema.PatternExamples.Behavioural.Iterator;

public class Container : INullable
{
    public object? content;
    public Container? next = null;
    public bool IsNull => content == null;
}