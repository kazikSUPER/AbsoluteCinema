using AbsoluteCinema.PatternExamples.Behavioural.Observer.Abstraction;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Observer.Implementation;

public class EmailSubscriber(string email) : IMovieObserver
{
    public void Update(string eventType, object data)
    {
        Console.WriteLine($"  [EmailSubscriber {email}] Received notification: {eventType}");

        switch (eventType)
        {
            case "NewMovieRelease":
                var movie = data as MovieRelease;
                Console.WriteLine($"    Sending email about '{movie?.Title}' release");
                break;

            case "PriceChange":
                var priceChange = data as PriceChangeInfo;
                Console.WriteLine($"    Sending email about {priceChange?.SubscriptionType} price change to ${priceChange?.NewPrice}");
                break;

            case "SpecialScreening":
                var screening = data as SpecialScreening;
                Console.WriteLine($"    Sending email about special screening of '{screening?.MovieTitle}'");
                break;
        }
    }

    public string GetIdentifier() => $"Email: {email}";
}