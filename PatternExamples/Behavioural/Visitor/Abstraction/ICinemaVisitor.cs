using AbsoluteCinema.PatternExamples.Behavioural.Visitor.Implementation;

namespace AbsoluteCinema.PatternExamples.Behavioural.Visitor.Abstraction;

public interface ICinemaVisitor
{
    void VisitMovie(MovieElement movie);
    void VisitSubscription(SubscriptionElement subscription);
    void VisitTicket(TicketElement ticket);
}