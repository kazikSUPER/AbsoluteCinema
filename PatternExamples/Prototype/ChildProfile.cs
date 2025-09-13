namespace AbsoluteCinema.PatternExamples.Prototype;

public class ChildProfile : Profile
{
    public ChildProfile(string name) : base(name)
    {
        this.IsAdult = false;
    }

    override public Profile Clone()
    {
        return (ChildProfile)MemberwiseClone();
    }

    override public Profile DeepClone()
    {
        return new ChildProfile(Name);
    }
}