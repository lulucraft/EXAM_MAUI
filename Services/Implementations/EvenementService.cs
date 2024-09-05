using EXAM_MAUI.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EXAM_MAUI.Services.Implementations
{
    public partial class EvenementService(ArkoneLajContext context) : IEvenementService
    {
        public async Task<List<Evenement>> GetEvenementsAsync()
        {
            return await context.Evenements.Include(e => e.SousEvenements).ToListAsync();
        }

        public async Task<(List<Evenement>, int)> GetEvenementsPaginationAsync(int pageNbr, int pageSize)
        {
            int totalEvenements = await context.Evenements.CountAsync();
            List<Evenement> evenements = await context.Evenements
                .Include(e => e.SousEvenements)
                .Include(e => e.IdInvites)
                .OrderBy(i => i.IdEvenement)
                .Skip((pageNbr - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (evenements, totalEvenements);
            //return await context.Evenements.Include(e => e.SousEvenements).ToListAsync();
        }

        public IEnumerable<Evenement> GetEvenement(string nom)
        {
            return context.Evenements.Where(e => e.Nom.Equals(nom));
        }

        public EntityEntry<Evenement> UpdateEvenement(Evenement evenement)
        {
            return context.Update(evenement);
        }

        public async Task<EntityEntry<Evenement>> CreateEvenementAsync(Evenement evenement) => await context.Evenements.AddAsync(evenement);

        public EntityEntry<Evenement> Add(Evenement evenement)
        {
            return context.Add(evenement);
        }

        //public void SaveChanges()
        //{
        //    context.SaveChanges();
        //}

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();

        public async Task<int> CountAsync() => await context.Evenements.CountAsync();

        //public void AddModifiedEntity(Evenement evenement)
        //{
        //    context.Entry(evenement).State = EntityState.Modified;
        //}
    }
}
