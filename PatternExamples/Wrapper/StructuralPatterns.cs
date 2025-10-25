using AbsoluteCinema.PatternExamples.Creational.StaticFactory;
using AbsoluteCinema.PatternExamples.Shared.Enums;
using AbsoluteCinema.PatternExamples.Shared.Models;
using AbsoluteCinema.PatternExamples.Structural.Adapter;
using AbsoluteCinema.PatternExamples.Structural.Bridge.Implementation.Channels;
using AbsoluteCinema.PatternExamples.Structural.Bridge.Implementation.NotificationType;
using AbsoluteCinema.PatternExamples.Structural.Composite;
using AbsoluteCinema.PatternExamples.Structural.Decorator;
using AbsoluteCinema.PatternExamples.Structural.Proxy;

namespace AbsoluteCinema.PatternExamples.Wrapper;

public static class StructuralPatterns
{
    public static void Demo()
    {
        AdapterDemo();
        BridgeDemo();
        CompositeDemo();
        FlyWeightDemo();
        DecoratorDemo();
        ProxyDemo();
    }

    public static void AdapterDemo()
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

    public static void BridgeDemo()
    {
        var emailChannel = new EmailChannel();
        var smsChannel = new SmsChannel();

        var movieNotification = new MovieReleaseNotification(emailChannel);
        movieNotification.SendNotification("One Punch Man: Eplogue is now available!", "user@example.com");

        var subscriptionNotification = new SubscriptionExpiryNotification(smsChannel);
        subscriptionNotification.SendNotification("Your subscription expires in 3 days", "+1234567890");
    }

    public static void CompositeDemo()
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

    public static void FlyWeightDemo()
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

    public static void DecoratorDemo()
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

    public static void ProxyDemo()
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
}