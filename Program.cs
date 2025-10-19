using AbsoluteCinema.PatternExamples.Creational.AbstractFactory;
using AbsoluteCinema.PatternExamples.Creational.Builder;
using AbsoluteCinema.PatternExamples.Creational.FactoryMethod;
using AbsoluteCinema.PatternExamples.Creational.ObjectPool;
using AbsoluteCinema.PatternExamples.Creational.Prototype;
using AbsoluteCinema.PatternExamples.Creational.SingleTone;
using AbsoluteCinema.PatternExamples.Creational.StaticFactory;
using AbsoluteCinema.PatternExamples.Shared.Enums;
using AbsoluteCinema.PatternExamples.Shared.Models;
using AbsoluteCinema.PatternExamples.Structural.Adapter;
using AbsoluteCinema.PatternExamples.Structural.Bridge.Implementation.Channels;
using AbsoluteCinema.PatternExamples.Structural.Bridge.Implementation.NotificationType;
using AbsoluteCinema.PatternExamples.Structural.Composite;
using AbsoluteCinema.PatternExamples.Structural.Decorator;
using AbsoluteCinema.PatternExamples.Structural.Proxy;

namespace AbsoluteCinema;

class Program
{
    public static void Main()
    {
        /////////////////////////////////
        //SingletoneDemo();
        //PrototypeDemo();
        //FactoryMethodDemo();
        //AbstractFactoryDemo();
        //BuilderDemo();
        //ObjectPoolDemo();
        /////////////////////////////////
        
        ////////////////////////////////
        Console.WriteLine("\nAdapterDemo:\n");
        AdapterDemo();
        Console.WriteLine("\nBridgeDemo:\n");
        BridgeDemo();
        Console.WriteLine("\nCompositeDemo:\n");
        CompositeDemo();
        Console.WriteLine("\nFlyWeightDemo:\n");
        FlyWeightDemo();
        Console.WriteLine("\nDecoratorDemo:\n");
        DecoratorDemo();
        Console.WriteLine("\nProxyDemo:\n");
        ProxyDemo();
        ////
    }

    #region Creational Patterns

    private static void SingletoneDemo()
    {
        Console.WriteLine("1. SINGLETON\n");

        var kazimirService = DatabaseService.Instance;
        Console.WriteLine($"First instance ID: {kazimirService.GetID()}");

        kazimirService.CreateItem().Wait();
        kazimirService.UpdateItem().Wait();

        var kazimirServiceAlt = DatabaseService.Instance;
        Console.WriteLine($"Second instance ID: {kazimirServiceAlt.GetID()}");

        bool areSame = ReferenceEquals(kazimirService, kazimirServiceAlt);
        Console.WriteLine($"\nAre both instances the same? {areSame}");
        Console.WriteLine($"Instance 1 hash: {kazimirService.GetHashCode()}");
        Console.WriteLine($"Instance 2 hash: {kazimirServiceAlt.GetHashCode()}");

        kazimirServiceAlt.DeleteItem().Wait();
    }

    private static void PrototypeDemo()
    {
        Console.WriteLine("\n2. PROTOTYPE\n");

        Console.WriteLine("Creating original profiles:\n");

        Profile adultProfile = new AdultProfile("kazikSuper");
        Profile childProfile = new ChildProfile("vladislave");

        Console.WriteLine($"Original Adult Profile: {adultProfile.GetType().Name}");
        Console.WriteLine($"Original Child Profile: {childProfile.GetType().Name}");

        Console.WriteLine("\nCloning profiles...\n");

        var clonedAdult = adultProfile.Clone();
        var clonedChild = childProfile.Clone();

        Console.WriteLine($"Cloned Adult Profile: {clonedAdult.GetType().Name}");
        Console.WriteLine($"Cloned Child Profile: {clonedChild.GetType().Name}");

        Console.WriteLine("\nDeep cloning profiles...\n");

        var deepClonedAdult = adultProfile.DeepClone();
        var deepClonedChild = childProfile.DeepClone();

        Console.WriteLine($"Deep Cloned Adult Profile: {deepClonedAdult.GetType().Name}");
        Console.WriteLine($"Deep Cloned Child Profile: {deepClonedChild.GetType().Name}");

        Console.WriteLine(
            $"\nOriginal and cloned are different objects? {!ReferenceEquals(adultProfile, clonedAdult)}");
        Console.WriteLine(
            $"Original and deep cloned are different objects? {!ReferenceEquals(adultProfile, deepClonedAdult)}");
    }

    private static void FactoryMethodDemo()
    {
        Console.WriteLine("\n3. FACTORY METHOD PATTERN\n");

        IProfileFactory adultFactory = new AdultProfileFactory();
        IProfileFactory childFactory = new ChildProfileFactory();

        Console.WriteLine("1. Using Adult Profile Factory:");
        var adult1 = adultFactory.CreateProfile();
        var adult2 = adultFactory.CreateProfile();
        Console.WriteLine($"   Created: {adult1.GetType().Name}");
        Console.WriteLine($"   Created: {adult2.GetType().Name}");

        Console.WriteLine("\n2. Using Child Profile Factory:");
        var child1 = childFactory.CreateProfile();
        var child2 = childFactory.CreateProfile();
        Console.WriteLine($"   Created: {child1.GetType().Name}");
        Console.WriteLine($"   Created: {child2.GetType().Name}");

        Console.WriteLine("\n3. Polymorphic factory usage:");
        ProcessProfileCreation(adultFactory, "Adult");
        ProcessProfileCreation(childFactory, "Child");
    }

    private static void ProcessProfileCreation(IProfileFactory factory, string factoryType)
    {
        Console.WriteLine($"   Processing with {factoryType} Factory:");
        var profile = factory.CreateProfile();
        Console.WriteLine($"   - Created profile type: {profile.GetType().Name}");
    }

    private static void AbstractFactoryDemo()
    {
        Console.WriteLine("\n4.ABSTRACT FACTORY\n");
        Console.WriteLine("1. Creating Family Content Package:");
        Console.WriteLine("Using FamilyContentFactory to create related objects:\n");

        IMovieFactory familyFactory = new FamilyContentFactory();

        var familyMovie = familyFactory.CreateMovie();
        var familySubscription = familyFactory.CreateSubscription();
        var familyProfile = familyFactory.CreateViewerProfile();

        Console.WriteLine(
            $"EYOOO: {familySubscription.GetPlanName()}, {familySubscription.GetMaxQuality()}, {familySubscription.GetPrice()}"
        );

        familyMovie.Play();
        familySubscription.Activate();
        Console.WriteLine($"   Profile created: {familyProfile.GetType().Name}");
    }

    private static void BuilderDemo()
    {
        Console.WriteLine("\n5. BUILDER PATTERN\n");

        var tBuilder = new TicketBuilder
        {
            Builder = new StandardTicketBuilder()
        };

        Console.WriteLine("1. Building Standard Tickets:\n");

        var standardBuilder = new StandardTicketBuilder();
        tBuilder.SetBuilder(standardBuilder);

        Console.WriteLine("a) Basic Standard Ticket:");
        var basicTicket = tBuilder.BuildBasicTicket(
            "The Matrix",
            DateTime.Now.AddDays(1),
            "Hall A",
            1, 23
        );
        basicTicket.ShowTicket();

        Console.WriteLine("\nb) Full Experience Standard Ticket:");
        var fullTicket = tBuilder.BuildFullExperienceTicket(
            "Avatar",
            DateTime.Now.AddDays(1).AddHours(23),
            "Hall B",
            7, 15
        );
        fullTicket.ShowTicket();

        Console.WriteLine("\n2. Building Premium Tickets:\n");

        var premiumBuilder = new PremiumTicketBuilder();
        tBuilder.SetBuilder(premiumBuilder);

        Console.WriteLine("a) VIP Premium Ticket:");
        var vipTicket = tBuilder.BuildVipTicket(
            "Oppenheimer",
            DateTime.Now.AddDays(3).AddHours(20),
            "IMAX Hall",
            1, 8
        );
        vipTicket.ShowTicket();

        Console.WriteLine("\nb) On-go build:");
        var customTicket = new StandardTicketBuilder()
            .SetMovie("Green Mile")
            .SetShowTime(DateTime.Now.AddDays(5).AddHours(21))
            .SetCinemaHall("Premium Hall")
            .SetSeat(3, 10)
            .AddPopcorn()
            .CalculatePrice()
            .Build();
        customTicket.ShowTicket();

    }

    private static void ObjectPoolDemo()
    {
        Console.WriteLine("\n6. OBJECT POOL PATTERN\n");

        var streamPool = new VideoStreamPool(maxPoolSize: 3);
        var streamingService = new StreamingService(streamPool);

        Console.WriteLine("Multiple users watching movies:\n");

        var thrdA = new Thread(() =>
        {
            streamPool.GetPoolStatus();
            streamingService.StartMovieForUser("kazik", "The Godfather", "4K");
        });
        thrdA.Start();

        var thrdB = new Thread(() =>
        {
            streamingService.StartMovieForUser("vladyslave", "Drunken Master 2");
            streamingService.ShowActiveUsers();
        });
        thrdB.Start();

        streamPool.GetPoolStatus();
        streamingService.StartMovieForUser("usr3", "Interstellar", "4K");
        Console.WriteLine("\nusr4 trying to connect:");
        streamingService.StartMovieForUser("usr4", "Green Mile");

        streamPool.GetPoolStatus();
        streamingService.StopMovieForUser("kazik");
        Console.WriteLine("\nusr4 trying again after kazik stopped:");
        streamingService.StartMovieForUser("usr4", "Green Mile");
        streamingService.ShowActiveUsers();
        streamPool.GetPoolStatus();
        streamingService.StopMovieForUser("vladyslave");
        streamingService.StartMovieForUser("usr5", "Drunken Master", "720p");

        Console.WriteLine("\nFinal status:");
        streamingService.ShowActiveUsers();
        streamPool.GetPoolStatus();

        Console.WriteLine("\nCleaning up all streams:");
        streamPool.Cleanup();
        streamPool.GetPoolStatus();
    }

    #endregion

    #region Structural Pattenrs

    private static void AdapterDemo()
    {
        var movies = new List<Movie>
        {
            new("blah-blah", 2007, "ABCD", GenreType.Action, "MP4"),
            new("123b", 2008, "EFGH", GenreType.Horror, "AVI"),
            new("Shrek", 2006, "IKLM", GenreType.Comedy, "MKV"),
            new("another blah-blah", 2009, "OP", GenreType.Thriller, "MKV"),
            new("b321", 2005, "RSTQ", GenreType.Romance, "MP4")
        };
        foreach (var movie in movies)
        {
            if (movie.Format != "MP4")
            {
                /*Console.WriteLine($"Sorry, you can't play this movie with {movie.Format}\n");*/
                MovieConverter.ConvertMovieToMp4(movie);
            }
            movie.Display();
            movie.Play();
        }
    }

    private static void BridgeDemo()
    {
        var emailChannel = new EmailChannel();
        var smsChannel = new SmsChannel();

        var movieNotification = new MovieReleaseNotification(emailChannel);
        movieNotification.SendNotification("One Punch Man: Eplogue is now available!", "user@example.com");

        var subscriptionNotification = new SubscriptionExpiryNotification(smsChannel);
        subscriptionNotification.SendNotification("Your subscription expires in 3 days", "+1234567890");
    }

    private static void CompositeDemo()
    {
        var CompositeExample = new Composite
        {
            Category = "Long Film",
            Movies = new List<IComponent>
            {
                new Composite
                {
                    Category = "Comedy",
                    Movies = new List<IComponent>
                    {
                        new Composite
                        {
                            Category = "Stand-up Comedy",
                            Movies = new List<IComponent>
                            {
                                new Leaf
                                {
                                    movie = new ("123b", 2008, "EFGH", GenreType.Horror, "MP4")
                                }
                            }
                        },
                        new Leaf
                        {
                            movie = new("blah-blah", 2007, "ABCD", GenreType.Action, "MP4")
                        }
                    }
                },
                new Composite
                {
                    Category = "Thriller",
                    Movies = new List<IComponent>
                    {
                        new Leaf
                        {
                            movie = new("another blah-blah", 2009, "OP", GenreType.Thriller, "MP4")
                        }
                    }
                },
                new Composite
                {
                    Category = "Horror",
                    Movies = new List<IComponent>
                    {
                        new Leaf
                        {
                            movie = new("b321", 2005, "RSTQ", GenreType.Romance, "MP4")
                        }
                    }
                },
                new Leaf
                {
                    movie = new("Shrek", 2006, "IKLM", GenreType.Comedy, "MP4")
                }
            }
        };
        Console.WriteLine($"Amount of movies: {CompositeExample.Count()}");
    }

    private static void FlyWeightDemo()
    {
        var movies = new List<Movie>
        {
            new("blah-blah", 2007, "ABCD", GenreType.Action, "MP4"),
            new("123b", 2008, "EFGH", GenreType.Horror, "MP4"),
            new("Shrek", 2006, "IKLM", GenreType.Comedy, "MP4"),
            new("another blah-blah", 2009, "OP", GenreType.Thriller, "MP4"),
            new("b321", 2005, "RSTQ", GenreType.Romance, "MP4")
        };

        foreach (var movie in movies)
        {
            movie.Display();
            Console.WriteLine();
        }

        Console.WriteLine($"Total genre flyweights created: {GenreFactory.GetCreatedGenresCount()}");

    }

    private static void DecoratorDemo()
    {
        IAccount Acc1 = new Account
        {
            Name = "Acc1",
            Age = 20
        };
        IAccount Acc2 = new Account
        {
            Name = "Acc2",
            Age = 25
        };
        Console.WriteLine(Acc1.GetAccount() + "\n" + Acc2.GetAccount());
        Acc1 = new HDAccount(Acc1);
        Acc2 = new DownloaderAccount(Acc2);
        Console.WriteLine("--------------------------");
        Console.WriteLine(Acc1.GetAccount() + "\n" + Acc2.GetAccount());
        Acc1 = new DownloaderAccount(Acc1);
        Console.WriteLine("--------------------------");
        Console.WriteLine(Acc1.GetAccount() + "\n" + Acc2.GetAccount());
    }

    private static void ProxyDemo()
    {
        var movieProxy = new MovieDatabaseProxy();

        Console.WriteLine("fetch from remote server:");
        var details = movieProxy.GetMovieDetails("movie123");
        Console.WriteLine(details);

        Console.WriteLine("\nusing cache:");
        details = movieProxy.GetMovieDetails("movie123");
        Console.WriteLine(details);

        Console.WriteLine("\nfetching reviews:");
        var reviews = movieProxy.GetMovieReviews("movie123");
        reviews.ForEach(Console.WriteLine);

        Console.WriteLine("\nupdating rating:");
        movieProxy.UpdateMovieRating("movie123", 8.5);
    }


    #endregion

}

