namespace AbsoluteCinema.PatternExamples.Prototype;

public class AdultProfile : Profile
{
    public AdultProfile(string name) : base(name)
    {
        this.IsAdult = true;
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