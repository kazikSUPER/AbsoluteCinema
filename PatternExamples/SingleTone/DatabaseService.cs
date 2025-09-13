namespace AbsoluteCinema.PatternExamples.SingleTone;

public class DatabaseService
{
    public static DatabaseService Instance = new();
    private int ID;
    private DatabaseService()
    {
        ID = Random.Shared.Next(1, 10);
        Console.WriteLine("Database service initialized");
    }
    
    public int GetID() => ID;

    public async Task CreateItem()
    {
        Console.WriteLine("Database item created");
    }

    public async Task DeleteItem()
    {
        Console.WriteLine("Database item deleted");
    }

    public async Task UpdateItem()
    {
        Console.WriteLine("Database item updated");
    }
}