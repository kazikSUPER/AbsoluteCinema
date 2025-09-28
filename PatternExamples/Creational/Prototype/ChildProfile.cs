namespace AbsoluteCinema.PatternExamples.Creational.Prototype;

public class ChildProfile : Profile
{
    public ChildProfile(string name) : base(name)
    {
        IsAdult = false;
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