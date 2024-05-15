using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RobinsonSportApp.Core.Constants;
using RobinsonSportApp.Core.CustomExceptions;
using RobinsonSportApp.Core.Managers.EventComments.NewFolder;
using RobinsonSportApp.Data;
using RobinsonSportApp.Data.Entities;
using System.Net;

namespace RobinsonSportApp.Core.Managers.EventComments;

internal class EventCommentManager(RobinsonSportAppDbContext _dbContext, IMapper _mapper) : IEventCommentManager
{
    public async Task<List<EventCommentModel>> GetEventCommentsAsync(long eventId, CancellationToken cancellationToken = default)
    {

        var eventComments = await _dbContext.EventComments.Where(ec => ec.EventId == eventId)
                                                          .ToListAsync(cancellationToken);
        return _mapper.Map<List<EventCommentModel>>(eventComments);
    }

    public async Task AddCommentAsync(AddCommentModel model, CancellationToken cancellationToken = default)
    {
        var eventComment = _mapper.Map<EventComment>(model);
        await _dbContext.EventComments.AddAsync(eventComment, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteCommentAsync(long id, CancellationToken cancellationToken = default)
    {
        var eventComment = await _dbContext.EventComments.FirstOrDefaultAsync(ec => ec.Id == id, cancellationToken)
                                 ?? throw new RBException(ErrorMessages.EventCommentNotFound, HttpStatusCode.NotFound);
        _dbContext.EventComments.Remove(eventComment);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
