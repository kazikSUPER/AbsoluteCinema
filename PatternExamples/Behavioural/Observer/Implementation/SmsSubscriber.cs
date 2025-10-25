using AbsoluteCinema.PatternExamples.Behavioural.Observer.Abstraction;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Observer.Implementation;

public class SmsSubscriber(string phoneNumber) : IMovieObserver
{
    public void Update(string eventType, object data)
    {
        Console.WriteLine($"  [SmsSubscriber {phoneNumber}] Received notification: {eventType}");

        switch (eventType)
        {
            case "NewMovieRelease":
                var movie = data as MovieRelease;
                Console.WriteLine($"    Sending SMS: New movie '{movie?.Title}' coming soon!");
                break;

            case "PriceChange":
                Console.WriteLine($"    Sending SMS: Subscription prices updated");
                break;

            case "SpecialScreening":
                var screening = data as SpecialScreening;
                Console.WriteLine($"    Sending SMS: Special screening of '{screening?.MovieTitle}'");
                break;
        }
    }

    public string GetIdentifier() => $"Phone: {phoneNumber}";
}