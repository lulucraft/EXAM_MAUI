using EXAM_MAUI.Context.Models;

namespace EXAM_MAUI.ViewModels
{
    [QueryProperty(nameof(Evenement), "data")]
    public partial class FicheStatViewModel(IDialogService dialogService, INavigationService navigationService, IInviteService inviteService, IEvenementService evenementService) : BaseViewModel(dialogService, navigationService, inviteService, evenementService)
    {
        [ObservableProperty]
        private Evenement _evenement = new();

        [RelayCommand]
        private async Task RetourAsync() => await NavigationService.GoBackAsync();

    }
}
