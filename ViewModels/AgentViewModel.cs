using EXAM_MAUI.Context.Models;
using Microsoft.IdentityModel.Tokens;

namespace EXAM_MAUI.ViewModels
{
    public partial class AgentViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? inputCode;

        public AgentViewModel(IDialogService dialogService, INavigationService navigationService, IInviteService inviteService, IEvenementService evenementService) : base(dialogService, navigationService, inviteService, evenementService)
        {
        }

        [RelayCommand]
        private async Task ValiderAsync(string code)
        {
            if (code.IsNullOrEmpty() || code.Length != 6)
            {
                await DialogService.DisplayAlertAsync("Erreur", "Le code doit avoir 6 caractères", "Ok");
                return;
            }

            Invite? invite = InviteService!.GetInvite(code).FirstOrDefault();
            if (invite == null)
            {
                await DialogService.DisplayAlertAsync("Erreur", "Aucun invité ne porte ce code", "Ok");
                return;
            }

            await DialogService.DisplayAlertAsync("Succès", "L'entrée est autorisée.", "Ok");

            // Traitement invité
            invite.PresenceInvite = true;
            await InviteService.SaveChangesAsync();
        }

    }
}
