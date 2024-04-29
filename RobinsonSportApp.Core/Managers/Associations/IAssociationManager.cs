using RobinsonSportApp.Core.Managers.Associations.Models;

namespace RobinsonSportApp.Core.Managers.Associations
{
    public interface IAssociationManager
    {
        Task<List<AssociationModel>> GetAssociationsAsync(CancellationToken cancellationToken = default);
        Task UpdateAssociationAsync(UpdateAssociationModel model, CancellationToken cancellationToken = default);
        Task DeleteAssociationAsync(int id, CancellationToken cancellationToken = default);
    }
}
