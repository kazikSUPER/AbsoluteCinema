namespace AbsoluteCinema.PatternExamples.Creational.Prototype;

public class FamilyProfile : Profile
{
    public FamilyProfile(string name) : base(name)
    {
        IsAdult = false;
    }

    public override Profile Clone()
    {
        return (FamilyProfile) MemberwiseClone();
    }

    public override Profile DeepClone()
    {
        return new FamilyProfile(Name);
    }
}