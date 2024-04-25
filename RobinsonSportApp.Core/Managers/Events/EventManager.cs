using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RobinsonSportApp.Core.Constants;
using RobinsonSportApp.Core.CustomExceptions;
using RobinsonSportApp.Core.Managers.Events.Models;
using RobinsonSportApp.Data;
using RobinsonSportApp.Data.Entities;
using System.Net;

namespace RobinsonSportApp.Core.Managers.Events;

internal class EventManager(RobinsonSportAppDbContext _dbContext, IMapper _mapper) : IEventManager
{
    public async Task AddEventAsync(AddEventModel model, CancellationToken cancellationToken = default)
    {
        var dbEvent = _mapper.Map<Event>(model);
        await _dbContext.Events.AddAsync(dbEvent, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteEventAsync(long id, CancellationToken cancellationToken = default)
    {
        var matchEvent = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == id, cancellationToken)
                               ?? throw new RBException(ErrorMessages.EventNotFound, HttpStatusCode.NotFound);
        _dbContext.Events.Remove(matchEvent);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<EventDetailedModel> GetEventAsync(long id, CancellationToken cancellationToken = default)
    {
        var matchEvent = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == id, cancellationToken)
                               ?? throw new RBException(ErrorMessages.EventNotFound, HttpStatusCode.NotFound);
        return _mapper.Map<EventDetailedModel>(matchEvent);
    }

    public async Task<List<EventModel>> GetEventsAsync(CancellationToken cancellationToken = default)
    {
        var events = await _dbContext.Events.OrderByDescending(e => e.Id).ToListAsync(cancellationToken);
        return _mapper.Map<List<EventModel>>(events);
    }

    public async Task UpdateEventAsync(UpdateEventModel model, CancellationToken cancellationToken = default)
    {
        var matchEvent = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == model.Id, cancellationToken)
                               ?? throw new RBException(ErrorMessages.EventNotFound, HttpStatusCode.NotFound);

        _mapper.Map(model, matchEvent);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
