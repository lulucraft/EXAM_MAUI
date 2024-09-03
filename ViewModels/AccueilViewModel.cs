namespace EXAM_MAUI.ViewModels
{
    public partial class AccueilViewModel(IDialogService dialogService, INavigationService navigationService) : BaseViewModel(dialogService, navigationService)
    {
        [RelayCommand]
        private Task LoginAsync() => NavigationService.GoToAsync("//home");
    }
}
