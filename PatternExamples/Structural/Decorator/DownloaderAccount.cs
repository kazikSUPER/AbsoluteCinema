namespace AbsoluteCinema.PatternExamples.Structural.Decorator;

public class DownloaderAccount : IAccount
{
    private IAccount _account;

    public DownloaderAccount(IAccount account)
    {
        _account = account;
    }
    public string GetAccount()
    {
        return _account.GetAccount() + ", Downloader";
    }
}