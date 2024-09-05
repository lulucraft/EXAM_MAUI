using EXAM_MAUI.Context.Models;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace EXAM_MAUI.ViewModels
{
    [QueryProperty(nameof(Context.Models.Evenement), "data")]
    public partial class EditionEvenementViewModel : BaseViewModel
    {
        private static readonly Regex regex = new(@"-?\d{1,3}\.\d+,\s*-?\d{1,3}\.\d+", RegexOptions.Compiled);

        [ObservableProperty]
        private string? _texteRecherche;

        [ObservableProperty]
        private Evenement _evenement;

        [ObservableProperty]
        private ObservableCollection<Invite> _invites = [];

        public EditionEvenementViewModel(IDialogService dialogService, INavigationService navigationService, IInviteService inviteService, IEvenementService evenementService) : base(dialogService, navigationService, inviteService, evenementService)
        {
            // Initialiser la propriété Evenement ici
            Evenement = new Evenement
            {
                DateEvenement = DateTime.Now // Initialisation date par défaut
            };
        }

        [RelayCommand]
        private async Task EnregistrerAsync()
        {
            string? nom = Evenement.Nom;

            if (string.IsNullOrEmpty(nom))
            {
                await DialogService.DisplayAlertAsync("Erreur", "Le nom est vide", "Ok");
                return;
            }

            string? lieu = Evenement.LieuEvenement;

            if (string.IsNullOrEmpty(lieu))
            {
                await DialogService.DisplayAlertAsync("Erreur", "Le lieu est vide", "Ok");
                return;
            }

            // 50.0,25.0,12.0
            string? coordonneesGPS = Evenement.CoordonneesGps;

            if (string.IsNullOrEmpty(coordonneesGPS) || !regex.IsMatch(coordonneesGPS))
            {
                await DialogService.DisplayAlertAsync("Erreur", "Les coordonnées GPS doivent correspondre au format requis : ex. 29.4209, 159.109", "Ok");
                return;
            }

            DateTime? date = Evenement.DateEvenement;

            if (!date.HasValue || date.Value < DateTime.Today)
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
                Evenement? even = EvenementService!.GetEvenement(Evenement.Nom).FirstOrDefault();
                if (even != null)
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
            //Enlève les espaces
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

        [RelayCommand]
        private async Task AjouterInviteAsync() => await NavigationService.GoToAsync(nameof(EditionInvitePage));

        [RelayCommand]
        private async Task AssocierInvite(Invite invite)
        {
            if (Evenement.IdInvites.Where(i => i.IdInvite == invite.IdInvite).FirstOrDefault() != null)
            {
                await DialogService.DisplayAlertAsync("Erreur", "Cet invité est déjà ajouté a l'événement", "Ok mec");
                return;
            }

            // Associe l'invité à l'événement et sauvegarde l'événement
            Evenement.IdInvites.Add(invite);
            //EvenementService!.UpdateEvenement(Evenement);
            await EvenementService!.SaveChangesAsync();
            Invites.Clear();
            TexteRecherche = string.Empty;
            //await NavigationService.GoBackAsync();
        }
    }
}
