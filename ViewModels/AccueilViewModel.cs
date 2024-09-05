using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EXAM_MAUI.ViewModels
{
    public partial class AccueilViewModel : BaseViewModel
    {
        [ObservableProperty]
        private int totalEvenements;

        [ObservableProperty]
        private int totalInvites;

        public AccueilViewModel(IDialogService dialogService, INavigationService navigationService, IInviteService inviteService, IEvenementService evenementService)
            : base(dialogService, navigationService, inviteService, evenementService)
        {
            LoadDashboardData();
        }

        // Méthode pour charger les données du dashboard
        private async void LoadDashboardData()
        {
            TotalEvenements = await EvenementService!.CountAsync();
            TotalInvites = await InviteService!.CountAsync();
        }

        // Commande pour la navigation vers AgentsPage
        [RelayCommand]
        private Task AgentsAsync() => NavigationService.GoToAsync(nameof(AgentPage));

        // Commande pour la navigation vers OrganisateurPage
        [RelayCommand]
        private Task EvenementsAsync() => NavigationService.GoToAsync(nameof(OrganisateurPage));
    }
}
