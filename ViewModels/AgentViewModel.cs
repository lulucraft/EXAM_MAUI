namespace EXAM_MAUI.ViewModels
{
    public partial class AgentViewModel(IDialogService dialogService, INavigationService navigationService) : BaseViewModel(dialogService, navigationService)
    {
        [RelayCommand]
        private Task AddEventAsync() => NavigationService.GoToAsync("newevent");
    }
}
