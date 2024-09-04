using EXAM_MAUI.Context.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EXAM_MAUI.Services
{
    public interface IEvenementService
    {
        Task<List<Evenement>> GetEvenementsAsync();

        Task<(List<Evenement>, int)> GetEvenementsPaginationAsync(int pageNbr, int pageSize);

        IEnumerable<Evenement> GetEvenement(string nom);

        EntityEntry<Evenement> UpdateEvenement(Evenement evenement);

        Task<EntityEntry<Evenement>> CreateEvenementAsync(Evenement evenement);

        EntityEntry<Evenement> Add(Evenement evenement);

        //void SaveChanges();

        Task SaveChangesAsync();
    }
}
