namespace RobinsonSportApp.Core.Managers.Subscription;

public interface ISubscriptionManager
{
    Task<bool> AddSubscription(string email, CancellationToken cancellationToken = default);
}
