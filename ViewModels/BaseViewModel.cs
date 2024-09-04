namespace EXAM_MAUI.ViewModels
{
    public partial class BaseViewModel(IDialogService dialogService, INavigationService navigationService) : ObservableObject
    {
        public IDialogService DialogService => dialogService;

        public INavigationService NavigationService => navigationService;

        public IInviteService? InviteService;

        public IEvenementService? EvenementService;

        [ObservableProperty]
        private string _title = string.Empty;

        public BaseViewModel(IDialogService dialogService, INavigationService navigationService, IInviteService inviteService, IEvenementService evenementService) : this(dialogService, navigationService)
        {
            InviteService = inviteService;
            EvenementService = evenementService;
        }
    }
}
