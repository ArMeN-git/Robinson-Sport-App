using RobinsonSportApp.Core.Managers.EventComments.NewFolder;

namespace RobinsonSportApp.Core.Managers.EventComments;

public interface IEventCommentManager
{
    Task<List<EventCommentModel>> GetEventCommentsAsync(long eventId, CancellationToken cancellationToken = default);
    Task AddCommentAsync(AddCommentModel model, CancellationToken cancellationToken = default);
    Task DeleteCommentAsync(long id, CancellationToken cancellationToken = default);
}
