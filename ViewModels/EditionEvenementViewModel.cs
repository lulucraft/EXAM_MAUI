using EXAM_MAUI.Context.Models;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace EXAM_MAUI.ViewModels
{
    [QueryProperty(nameof(Evenement), "data")]
    public partial class EditionEvenementViewModel(IDialogService dialogService, INavigationService navigationService, IInviteService inviteService, IEvenementService evenementService) : BaseViewModel(dialogService, navigationService, inviteService, evenementService)
    {
        private static readonly Regex regex = new Regex(@"-?\d{1,3}\.\d+,\s*-?\d{1,3}\.\d+", RegexOptions.Compiled);

        [ObservableProperty]
        private string? _texteRecherche;

        [ObservableProperty]
        private Evenement _evenement = new();

        [ObservableProperty]
        private ObservableCollection<Invite> _invites = [];

        [RelayCommand]
        private async Task EnregistrerAsync()
        {
            string nom = Evenement.Nom;

            if (string.IsNullOrEmpty(nom))
            {
                await DialogService.DisplayAlertAsync("Erreur", "La chaîne est vide", "Ok");
                return;

            }

            string coordonneesGPS = Evenement.CoordonneesGps;

            if (string.IsNullOrEmpty(coordonneesGPS) || !regex.IsMatch(coordonneesGPS))
            {
                await DialogService.DisplayAlertAsync("Erreur", "Les coordonnées GPS doivent correspondre au format requis : ex. 29.4209, 159.109", "Ok");
                return;
            }

            DateTime? date = Evenement.DateEvenement;

            if (date == null || date < DateTime.Now.Date)
            {
                await DialogService.DisplayAlertAsync("Erreur", "La date de l'événement ne peut pas être antérieure à la date d'aujourd'hui.", "Ok");
                return;

            }

            int? nbInvites = Evenement.NbInvites;

            if (nbInvites == null)
            {
                await DialogService.DisplayAlertAsync("Erreur", "La chaîne est vide", "Ok");
                return;
            }

            if (Evenement.IdEvenement == 0)
            {
                if (EvenementService!.GetEvenement(Evenement.Nom) != null)
                {
                    // Un événement porte déjà le nom entré
                    await DialogService.DisplayAlertAsync("Erreur", $"Un événement porte déjà le nom {Evenement.Nom}", "Ah merde");
                    return;
                }

                //var context = new ArkoneLajContext();
                //await DbContext.Materiau.AddAsync(Materiau);
                //await context.Evenements.AddAsync(Evenement);
                await EvenementService!.CreateEvenementAsync(Evenement);
                //EvenementService!.UpdateEvenement(Evenement);
                //await context.SaveChangesAsync();
                await EvenementService!.SaveChangesAsync();
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

        [RelayCommand]
        private async Task Recherche()
        {
            if (TexteRecherche == null)
            {
                await DialogService.DisplayAlertAsync("Erreur", "Veuillez entrer le code de l'invité", "Ok BG");
                return;
            }

            string input = TexteRecherche.Replace(" ", "");

            //IEnumerable<Invite> enumInvite = InviteService!.SearchInvite(input);
            List<Invite> invites = InviteService!.SearchInvite(input).ToList();
            if (invites == null || invites.Count == 0)
            {
                await DialogService.DisplayAlertAsync("Erreur", "Aucun invité n'a de code similaire à celui entré", "Ok");
                return;
            }

            // Invité(s) trouvé(s)
            Invites = [.. invites];
        }
    }
}
