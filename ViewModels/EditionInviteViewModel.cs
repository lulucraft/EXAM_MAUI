using EXAM_MAUI.Context.Models;
using System.Text.RegularExpressions;

namespace EXAM_MAUI.ViewModels
{
    [QueryProperty(nameof(Context.Models.Invite), "data")]
    public partial class EditionInviteViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Invite _invite = new();

        public EditionInviteViewModel(IDialogService dialogService, INavigationService navigationService, IInviteService inviteService, IEvenementService evenementService) : base(dialogService, navigationService, inviteService, evenementService)
        {
            GenerateCodeInvite();
        }

        [RelayCommand]
        private async Task EnregistrerAsync()
        {
            string? nom = Invite.NomInvite;

            if (string.IsNullOrEmpty(nom))
            {
                await DialogService.DisplayAlertAsync("Erreur", "La chaîne est vide", "Ok");
                return;
            }

            string? prenom = Invite.PrenomInvite;

            if (string.IsNullOrEmpty(prenom))
            {
                await DialogService.DisplayAlertAsync("Erreur", "La chaîne est vide", "Ok");
                return;
            }

            string? email = Invite.EmailInvite;

            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                await DialogService.DisplayAlertAsync("Erreur", "L'adresse email n'est pas au bon format", "Ok");
                return;
            }

            string? telephone = Invite.TelephoneInvite;

            if (string.IsNullOrEmpty(telephone) || !Regex.IsMatch(telephone, @"^(?:0|\+33)[1-9]\d{8}$"))
            {
                await DialogService.DisplayAlertAsync("Erreur", "Le numéro de téléphone n'est pas au bon format", "Ok");
                return;
            }

            if (Invite.IdInvite == 0)
            {
                await InviteService!.CreateInviteAsync(Invite);
                //EvenementService!.UpdateEvenement(Evenement);
                //await context.SaveChangesAsync();
                await InviteService!.SaveChangesAsync();
            }

            //await DbContext.SaveChangesAsync();
            await NavigationService.GoBackAsync();

        }

        [RelayCommand]
        private async Task AnnulerAsync()
        {
            //DbContext.ChangeTracker.Clear(); // Permet d'oublier les changements
            await NavigationService.GoBackAsync();
        }

        private void GenerateCodeInvite()
        {
            Random random = new();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] stringChars = new char[6];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            Invite.CodeInvite = new string(stringChars);
        }

    }
}