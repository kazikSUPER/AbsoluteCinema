namespace AbsoluteCinema.PatternExamples.Structural.Decorator;

public class HDAccount : IAccount
{
    private IAccount _account;

    public HDAccount(IAccount account)
    {
        _account = account;
    }
    public string GetAccount()
    {
        return _account.GetAccount() + ", HD-Quality";
    }
}