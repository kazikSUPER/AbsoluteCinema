namespace AbsoluteCinema.PatternExamples.Prototype;

public abstract class Profile
{
    protected string Name { get; set; }
    protected bool IsAdult {  get; set; }
    public abstract Profile Clone();
    public abstract Profile DeepClone();

    public Profile(string name)
    {
        this.Name = name;
    }
}