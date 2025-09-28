namespace AbsoluteCinema.PatternExamples.Creational.Prototype;

public class AdultProfile : Profile
{
    public AdultProfile(string name) : base(name)
    {
        IsAdult = true;
    }

    override public Profile Clone()
    {
        return (AdultProfile)MemberwiseClone();
    }

    override public Profile DeepClone()
    {
        return new AdultProfile(Name);
    }
}