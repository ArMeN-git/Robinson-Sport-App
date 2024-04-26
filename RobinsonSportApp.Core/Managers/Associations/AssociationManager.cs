using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RobinsonSportApp.Core.Constants;
using RobinsonSportApp.Core.CustomExceptions;
using RobinsonSportApp.Core.Managers.Associations.Models;
using RobinsonSportApp.Core.Managers.Events;
using RobinsonSportApp.Core.Managers.Events.Models;
using RobinsonSportApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RobinsonSportApp.Core.Managers.Associations
{
    internal class AssociationManager(RobinsonSportAppDbContext _dbContext, IMapper _mapper) : IAssociationManager
    {
        public async Task DeleteEventAsync(long id, CancellationToken cancellationToken = default)
        {
            var association = await _dbContext.Associations.FirstOrDefaultAsync(e => e.Id == id, cancellationToken)
                                   ?? throw new RBException(ErrorMessages.EventNotFound, HttpStatusCode.NotFound);
            _dbContext.Associations.Remove(association);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<List<AssociationModel>> GetEventsAsync(CancellationToken cancellationToken = default)
        {
            var associations = await _dbContext.Events.OrderByDescending(e => e.Id).ToListAsync(cancellationToken);
            return _mapper.Map<List<AssociationModel>>(associations);
        }

        public async Task UpdateAssociationAsync(UpdateEventModel model, CancellationToken cancellationToken = default)
        {
            var association = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == model.Id, cancellationToken)
                                   ?? throw new RBException(ErrorMessages.EventNotFound, HttpStatusCode.NotFound);

            _mapper.Map(model, association);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
