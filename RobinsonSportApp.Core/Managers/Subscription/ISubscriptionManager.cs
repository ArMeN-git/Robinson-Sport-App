namespace RobinsonSportApp.Core.Managers.Subscription;

public interface ISubscriptionManager
{
    Task<bool> AddSubscriptionAsync(string email, CancellationToken cancellationToken = default);
}
