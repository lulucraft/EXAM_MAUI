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
        private int _totalPages;

        [ObservableProperty]
        private int _pageNumber = 1;

        //[ObservableProperty]
        //private string pageDisplay;

        public string PageDisplay => $"{PageNumber}/{TotalCount}";

        //public OrganisateurViewModel(IDialogService dialogService, INavigationService navigationService, IInviteService inviteService, IEvenementService evenementService) : base(dialogService, navigationService, inviteService, evenementService)
        //{
        //    //LoadEvenements();
        //}

        private async void LoadEvenements()//int? pageNbr
        {
            //if (pageNbr != null) PageNumber = (int)pageNbr;
            (List<Evenement> evenements, int totalEvenements) = await EvenementService!.GetEvenementsPaginationAsync(PageNumber, 15);
            TotalPages = totalEvenements;
            Evenements = new ObservableCollection<Evenement>(evenements);
        }

        [RelayCommand]
        private void Actualiser() => LoadEvenements();

        [RelayCommand]
        private async Task AjouterEvenementAsync() => await NavigationService.GoToAsync(nameof(EditionEvenementPage));

        [RelayCommand]
        private async Task EditerEvenementAsync(Evenement evenement) => await NavigationService.GoToAsync(nameof(EditionEvenementPage), evenement);

        [RelayCommand]
        private async Task RetourAsync() => await NavigationService.GoBackAsync();

        [RelayCommand]
        private void PreviousPage()
        {
            if (PageNumber > 1 && PageNumber < TotalPages)
            {
                PageNumber = --PageNumber;
                LoadEvenements();
            }
        }

        [RelayCommand]
        private void NextPage()
        {
            if (PageNumber <= TotalPages)
            {
                PageNumber = ++PageNumber;
                LoadEvenements();
            }
        }
    }
}