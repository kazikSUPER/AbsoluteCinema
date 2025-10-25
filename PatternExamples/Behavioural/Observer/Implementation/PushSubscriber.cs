using AbsoluteCinema.PatternExamples.Behavioural.Observer.Abstraction;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Observer.Implementation;

public class PushNotificationSubscriber(string deviceToken) : IMovieObserver
{
    public void Update(string eventType, object data)
    {
        Console.WriteLine($"  [PushSubscriber {deviceToken}] Received notification: {eventType}");

        switch (eventType)
        {
            case "NewMovieRelease":
                var movie = data as MovieRelease;
                Console.WriteLine($"    Sending push: '{movie?.Title}' is coming!");
                break;

            case "PriceChange":
                var priceChange = data as PriceChangeInfo;
                Console.WriteLine($"    Sending push: Price update for {priceChange?.SubscriptionType}");
                break;

            case "SpecialScreening":
                var screening = data as SpecialScreening;
                Console.WriteLine($"    Sending push: Don't miss '{screening?.MovieTitle}'!");
                break;
        }
    }

    public string GetIdentifier() => $"Device: {deviceToken}";
}