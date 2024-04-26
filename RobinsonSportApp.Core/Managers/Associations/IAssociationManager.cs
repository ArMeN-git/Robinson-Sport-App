using RobinsonSportApp.Core.Managers.Associations.Models;
using RobinsonSportApp.Core.Managers.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinsonSportApp.Core.Managers.Associations
{
    public interface IAssociationManager
    {
        Task<List<AssociationModel>> GetAssociationsAsync(CancellationToken cancellationToken = default);
        Task UpdateAssociationAsync(UpdateAssociationModel model, CancellationToken cancellationToken = default);

        Task DeleteAssociationAsync(long id, CancellationToken cancellationToken = default);
    }
}
