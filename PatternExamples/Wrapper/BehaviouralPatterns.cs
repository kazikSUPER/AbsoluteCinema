using AbsoluteCinema.PatternExamples.Behavioural.Command.Abstraction;
using AbsoluteCinema.PatternExamples.Behavioural.Command.Implementation;
using AbsoluteCinema.PatternExamples.Behavioural.Command.Implementation.Helpers;
using AbsoluteCinema.PatternExamples.Behavioural.Iterator;
using AbsoluteCinema.PatternExamples.Behavioural.Mediator.Implementation;
using AbsoluteCinema.PatternExamples.Behavioural.Observer.Implementation;
using AbsoluteCinema.PatternExamples.Behavioural.ResponsibilityChain;
using AbsoluteCinema.PatternExamples.Behavioural.State;
using AbsoluteCinema.PatternExamples.Behavioural.Strategy.Implementation;
using AbsoluteCinema.PatternExamples.Behavioural.Template;
using AbsoluteCinema.PatternExamples.Behavioural.Visitor.Abstraction;
using AbsoluteCinema.PatternExamples.Behavioural.Visitor.Implementation;
using AbsoluteCinema.PatternExamples.Shared.Enums;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Wrapper;

public abstract class BehaviouralPatterns
{
    public static void Demo()
    {
        ResChainDemo();
        IteratorDemo();
        CommandDemo();
        MediatorDemo();
        ObserverDemo();
        StrategyDemo();
        VisitorDemo();
        MementoDemo();
        StateDemo();
        TemplateDemo();
    }

    public static void ResChainDemo()
    {
        Console.WriteLine("ResChainDemo:\n");
        var bot = new BotResponse();
        Console.WriteLine(bot.response("Bot 11010001010101010011010111010100101011"));
        Console.WriteLine(bot.response("Operator do something"));
        Console.WriteLine(bot.response("Admin report about problem"));
        Console.WriteLine(bot.response("Lemon Sicilian"));
    }

    public static void IteratorDemo()
    {
        Console.WriteLine("IteratorDemo:\n");
        var iter = new MovieIterator();
        iter.AddItem(new Movie("blah-blah", 2007, "ABCD", GenreType.Action, "MP4"));
        iter.AddItem(new Movie("another blah-blah", 2009, "OP", GenreType.Thriller, "MKV"));
        iter.AddItem(new Movie("Shrek", 2006, "IKLM", GenreType.Comedy, "MKV"));
        while (iter.HasNext())
        {
            iter.Next<Movie>().Display();
            Console.WriteLine();
        }
        iter.Next<Movie>().Display();
    }

    public static void CommandDemo()
    {
        var mediaPlayer = new MediaPlayer();

        ICommand playCommand = new PlayMovieCommand(mediaPlayer, "Shrek");
        ICommand pauseCommand = new PauseCommand(mediaPlayer);
        ICommand stopCommand = new StopCommand(mediaPlayer);

        var command = new CommandInvoker();

        Console.WriteLine("\n1. Playing movie:");
        command.SetCommand(playCommand);
        command.Invoke();

        Console.WriteLine("\n2. Pausing playback:");
        command.SetCommand(pauseCommand);
        command.Invoke();

        Console.WriteLine("\n3. Undoing pause:");
        command.Undo();

        Console.WriteLine("\n4. Stopping playback:");
        command.SetCommand(stopCommand);
        command.Invoke();

        Console.WriteLine("\n5. Macro commands:");
        var macroCommand = new MacroCommand([
            playCommand,
            pauseCommand,
            playCommand,
            stopCommand
        ]);

        command.SetCommand(macroCommand);
        command.Invoke();

        Console.WriteLine("\n6. Undoing macro command:");
        command.Undo();
    }

    public static void MediatorDemo()
    {
        var bookingSystem = new CinemaBookingMediator();

        var user1 = new User("Kazimir", bookingSystem);
        var user2 = new User("Repetovskyi", bookingSystem);
        var user3 = new User("Shpitz", bookingSystem);

        var hall1 = new CinemaHall("IMAX Hall", 50, bookingSystem);
        var hall2 = new CinemaHall("Standard Hall", 100, bookingSystem);

        var paymentSystem = new PaymentSystem(bookingSystem);
        var notificationService = new NotificationService(bookingSystem);

        bookingSystem.RegisterUser(user1);
        bookingSystem.RegisterUser(user2);
        bookingSystem.RegisterUser(user3);
        bookingSystem.RegisterHall(hall1);
        bookingSystem.RegisterHall(hall2);
        bookingSystem.RegisterPaymentSystem(paymentSystem);
        bookingSystem.RegisterNotificationService(notificationService);

        Console.WriteLine("1. User attempts to book seats:");
        user1.BookSeats("IMAX Hall", "The Matrix", 2);

        Console.WriteLine("\n2. Another user books in different hall:");
        user2.BookSeats("Standard Hall", "Inception", 3);

        Console.WriteLine("\n3. Third user tries to book many seats:");
        user3.BookSeats("IMAX Hall", "Interstellar", 55);

        Console.WriteLine("\n4. User cancels booking:");
        user1.CancelBooking();

        Console.WriteLine("\n5. Checking hall availability:");
        hall1.CheckAvailability();
        hall2.CheckAvailability();
    }

    public static void ObserverDemo()
    {
        var movieTracker = new MovieReleaseTracker();

        var emailSubscriber = new EmailSubscriber("kazimir@cinema.com");
        var smsSubscriber = new SmsSubscriber("+380501234567");
        var pushSubscriber = new PushNotificationSubscriber("DeviceToken123");

        Console.WriteLine("1. Adding subscribers:");
        movieTracker.Attach(emailSubscriber);
        movieTracker.Attach(smsSubscriber);
        movieTracker.Attach(pushSubscriber);

        Console.WriteLine("\n2. Announcing new movie:");
        movieTracker.AnnounceNewMovie("Dune: Part Three", DateTime.Now.AddMonths(6));

        Console.WriteLine("\n3. Announcing another movie:");
        movieTracker.AnnounceNewMovie("Avatar 3", DateTime.Now.AddMonths(12));

        Console.WriteLine("\n4. Removing SMS subscriber:");
        movieTracker.Detach(smsSubscriber);

        Console.WriteLine("\n5. Price change notification:");
        movieTracker.AnnouncePriceChange("Premium", 299.99m);

        Console.WriteLine("\n7. Special screening announcement:");
        movieTracker.AnnounceSpecialScreening("The Godfather", DateTime.Now.AddDays(7));
    }

    public static void StrategyDemo()
    {
        Console.WriteLine("\n6. Movie Search Strategies:");
        var searchContext = new MovieSearchContext();
        var movies = new List<Movie>
        {
            new("The Matrix", 1999, "Wachowski", GenreType.Action, "MP4"),
            new("Inception", 2010, "Christopher Nolan", GenreType.Thriller, "MP4"),
            new("The Godfather", 1972, "Francis Ford Coppola", GenreType.Drama, "MP4"),
            new("Pulp Fiction", 1994, "Quentin Tarantino", GenreType.Thriller, "MP4")
        };

        Console.WriteLine("\n   a) Search by Title:");
        searchContext.SetStrategy(new SearchByTitleStrategy());
        var results = searchContext.Search(movies, "The");
        Console.WriteLine($"      Found {results.Count} movies");

        Console.WriteLine("\n   b) Search by Genre:");
        searchContext.SetStrategy(new SearchByGenreStrategy());
        results = searchContext.Search(movies, "Thriller");
        Console.WriteLine($"      Found {results.Count} thriller movies");

    }

    public static void VisitorDemo()
    {
        var cinemaElements = new List<ICinemaElement>
        {
            new MovieElement(new Movie("The Shawshank Redemption", 1994, "Frank Darabont", GenreType.Drama, "MP4")),
            new SubscriptionElement("Premium", 29.99m, 12),
            new TicketElement("IMAX Hall", DateTime.Now.AddDays(1), 15.99m),
            new MovieElement(new Movie("Interstellar", 2014, "Christopher Nolan", GenreType.Drama, "MP4")),
            new SubscriptionElement("Standard", 14.99m, 6),
            new TicketElement("Standard Hall", DateTime.Now.AddHours(3), 9.99m)
        };

        Console.WriteLine("\n1. Report Generation Visitor:");
        var reportVisitor = new ReportGenerationVisitor();
        foreach (var element in cinemaElements)
        {
            element.Accept(reportVisitor);
        }
        reportVisitor.PrintReport();

        Console.WriteLine("\n2. Export to XML Visitor:");
        var xmlVisitor = new XmlExportVisitor();
        foreach (var element in cinemaElements)
        {
            element.Accept(xmlVisitor);
        }
        Console.WriteLine(xmlVisitor.GetXml());

        Console.WriteLine("\n3. Analytics Visitor:");
        var analyticsVisitor = new AnalyticsVisitor();
        foreach (var element in cinemaElements)
        {
            element.Accept(analyticsVisitor);
        }
        analyticsVisitor.PrintStatistics();
    }
    
    public static void MementoDemo()
    {
        var stream = new VideoStream(505);
        stream.StartStream(new Movie("The Godfather", 1980, "King", GenreType.Action, "MP4"), "kazik");
        var memento = stream.Save;
        var revisedStream = memento.Revise;
        revisedStream.StartStream(new Movie("The Godfather", 1980, "King", GenreType.Action, "MP4"), "kazik");
    }

    public static void StateDemo()
    {
        Account account = new ();
        account.Download();
        account.RankUp();
        account.Download();
        account.RankUp();
        account.Download();
        account.RankUp();
        account.Download();
        account.RankUp();
        account.Download();
    }

    public static void TemplateDemo()
    {
        var movie = new Movie("The Godfather", 1980, "King", GenreType.Action, "MP4");
        movie.Play(new ConvertTo480p(), new AddSubtitles());
        Console.WriteLine("||||||||||||||||||||||||||");
        movie.Play(new ConvertTo480p(), new NoSubtitles());
        Console.WriteLine("||||||||||||||||||||||||||");
        movie.Play(new ConvertTo720p(), new AddSubtitles());
    }
}