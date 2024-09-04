namespace EXAM_MAUI.ViewModels
{
    public partial class AccueilViewModel(IDialogService dialogService, INavigationService navigationService) : BaseViewModel(dialogService, navigationService)
    {
        [RelayCommand]
        private Task AgentsAsync() => NavigationService.GoToAsync(nameof(AgentPage));
        
        [RelayCommand]
        private Task EvenementsAsync() => NavigationService.GoToAsync(nameof(OrganisateurPage));
    }
}
