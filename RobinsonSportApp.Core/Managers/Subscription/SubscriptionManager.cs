using Microsoft.EntityFrameworkCore;
using RobinsonSportApp.Data;

namespace RobinsonSportApp.Core.Managers.Subscription;

internal class SubscriptionManager(RobinsonSportAppDbContext _dbContext) : ISubscriptionManager
{
    public async Task<bool> AddSubscription(string email, CancellationToken cancellationToken = default)
    {
        if (await _dbContext.Subscriptions.AnyAsync(s => s.Email == email, cancellationToken))
        {
            return false;
        }
        await _dbContext.Subscriptions.AddAsync(new Data.Entities.Subscription { Email = email }, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
