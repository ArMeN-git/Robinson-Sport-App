using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RobinsonSportApp.Core.Constants;
using RobinsonSportApp.Core.CustomExceptions;
using RobinsonSportApp.Core.Managers.Associations.Models;
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
        public async Task DeleteAssociationAsync(long id, CancellationToken cancellationToken = default)
        {
            var association = await _dbContext.Associations.FirstOrDefaultAsync(e => e.Id == id, cancellationToken)
                                   ?? throw new RBException(ErrorMessages.AssociationNotFound, HttpStatusCode.NotFound);
            _dbContext.Associations.Remove(association);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<List<AssociationModel>> GetAssociationsAsync(CancellationToken cancellationToken = default)
        {
            var associations = await _dbContext.Associations.OrderByDescending(e => e.Id).ToListAsync(cancellationToken);
            return _mapper.Map<List<AssociationModel>>(associations);
        }

        public async Task UpdateAssociationAsync(UpdateAssociationModel model, CancellationToken cancellationToken = default)
        {
            var association = await _dbContext.Associations.FirstOrDefaultAsync(e => e.Id == model.Id, cancellationToken)
                                   ?? throw new RBException(ErrorMessages.AssociationNotFound, HttpStatusCode.NotFound);

            _mapper.Map(model, association);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
