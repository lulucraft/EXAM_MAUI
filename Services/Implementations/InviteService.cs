using EXAM_MAUI.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
namespace EXAM_MAUI.Services.Implementations
{
    public partial class InviteService(ArkoneLajContext context) : IInviteService
    {
        public IEnumerable<Invite> GetInvite(string code)
        {
            return context.Invites.Where(i => i.CodeInvite == code);
        }

        public IEnumerable<Invite> SearchInvite(string code)
        {
            return context.Invites.AsNoTracking().Where(i => i.CodeInvite.Contains(code));
        }

        public EntityEntry<Invite> UpdateInvite(Invite invite)
        {
            return context.Update(invite);
        }

        public async Task<EntityEntry<Invite>> CreateInviteAsync(Invite invite) => await context.Invites.AddAsync(invite);

        public EntityEntry<Invite> Add(Invite invite)
        {
            return context.Add(invite);
        }

        //public void SaveChanges()
        //{
        //    context.SaveChanges();
        //}

        public async Task SaveChangesAsync()
        {
            // Sauvegarde des modifications
            await context.SaveChangesAsync();

            // Détachement de toutes les entités suivies
            // foreach (var entry in context.ChangeTracker.Entries().ToList())
            //  {
            // entry.State = EntityState.Detached;
            // }
        }

        public async Task<int> CountAsync() => await context.Invites.CountAsync();
    }
}
