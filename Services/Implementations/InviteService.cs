using EXAM_MAUI.Context.Models;
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
            return context.Invites.Where(i => i.CodeInvite.Contains(code));
        }

        public EntityEntry<Invite> UpdateInvite(Invite invite)
        {
            return context.Update(invite);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
