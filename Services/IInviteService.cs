using EXAM_MAUI.Context.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EXAM_MAUI.Services
{
	public interface IInviteService
    {
        IEnumerable<Invite> GetInvite(string code);

        IEnumerable<Invite> SearchInvite(string code);

        EntityEntry<Invite> UpdateInvite(Invite invite);

        Task<EntityEntry<Invite>> CreateInviteAsync(Invite invite);

        EntityEntry<Invite> Add(Invite invite);

        //void SaveChanges();

        Task SaveChangesAsync();

        Task<int> CountAsync();
    }
}
