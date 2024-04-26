using RobinsonSportApp.Core.Managers.Events.Models;

namespace RobinsonSportApp.Core.Managers.Events;

public interface IEventManager
{
    Task<List<EventModel>> GetRecentEventsAsync(int takeCount, CancellationToken cancellation = default);
    Task<List<EventModel>> GetUpcomingEventsAsync(int takeCount, CancellationToken cancellationToken = default);
    Task<List<EventModel>> GetLiveAndPastEventsAsync(CancellationToken cancellationToken = default);
    Task<EventDetailedModel> GetEventAsync(long id, CancellationToken cancellationToken = default);
    Task AddEventAsync(AddEventModel model, CancellationToken cancellationToken = default);
    Task UpdateEventAsync(UpdateEventModel model, CancellationToken cancellationToken = default);
    Task DeleteEventAsync(long id, CancellationToken cancellationToken = default);
}
