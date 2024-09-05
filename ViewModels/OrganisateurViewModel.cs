using EXAM_MAUI.Context.Models;
using EXAM_MAUI.Services.Implementations;
using EXAM_MAUI.Views;
using System.Collections.ObjectModel;

namespace EXAM_MAUI.ViewModels
{
    public partial class OrganisateurViewModel(IDialogService dialogService, INavigationService navigationService, IInviteService inviteService, IEvenementService evenementService) : BaseViewModel(dialogService, navigationService, inviteService, evenementService)
    {
        [ObservableProperty]
        private ObservableCollection<Evenement>? _evenements = [];

        [ObservableProperty]
        private int _totalCount;

        [ObservableProperty]
        private int _pageNumber = 1;

        [ObservableProperty]
        private int _itemsPerPage = 15;

        //[ObservableProperty]
        //private string pageDisplay;

        [ObservableProperty]
        public int _totalPages = 0;


        //public OrganisateurViewModel(IDialogService dialogService, INavigationService navigationService, IInviteService inviteService, IEvenementService evenementService) : base(dialogService, navigationService, inviteService, evenementService)
        //{
        //    //LoadEvenements();
        //}

        private async Task LoadEvenements()//int? pageNbr
        {
            //if (pageNbr != null) PageNumber = (int)pageNbr;
            (List<Evenement> evenements, int totalEvenements) = await EvenementService!.GetEvenementsPaginationAsync(PageNumber, ItemsPerPage);
            TotalCount = totalEvenements;
            //TotalPages = totalEvenements / ItemsPerPage;
            TotalPages = (int)Math.Ceiling((double)TotalCount / ItemsPerPage);
            Evenements = new ObservableCollection<Evenement>(evenements);
        }

        [RelayCommand]
        private async Task Actualiser() => await LoadEvenements();

        [RelayCommand]
        private async Task AjouterEvenementAsync() => await NavigationService.GoToAsync(nameof(EditionEvenementPage));

        [RelayCommand]
        private async Task EditerEvenementAsync(Evenement evenement) => await NavigationService.GoToAsync(nameof(EditionEvenementPage), evenement);

        [RelayCommand]
        private async Task RetourAsync() => await NavigationService.GoBackAsync();

        [RelayCommand]
        private async Task PreviousPage()
        {
            if (PageNumber > 1 && PageNumber <= TotalPages)
            {
                PageNumber = --PageNumber;
                await LoadEvenements();
            }
        }

        [RelayCommand]
        private async Task NextPage()
        {
            if (PageNumber < TotalPages)
            {
                PageNumber = ++PageNumber;
                await LoadEvenements();
            }
        }

        [RelayCommand]
        private async Task AfficherStatsAsync(Evenement evenement) => await NavigationService.GoToAsync(nameof(FicheStatPage), evenement);

        [RelayCommand]
        private async Task FirstPage()
        {
            PageNumber = 1;
            await LoadEvenements();
        }

        [RelayCommand]
        private async Task LastPage()
        {
            PageNumber = TotalPages;
            await LoadEvenements();
        }
    }
}