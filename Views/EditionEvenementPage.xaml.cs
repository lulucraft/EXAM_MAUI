namespace EXAM_MAUI.Views
{
    public partial class EditionEvenementPage : ContentPage
    {
        public EditionEvenementPage(EditionEvenementViewModel viewModel)
        {
            InitializeComponent();
            EditionEvenementViewModel model = new(viewModel.DialogService, viewModel.NavigationService, viewModel.InviteService!, viewModel.EvenementService!);
            model.Title = "Edition Evénement";
            BindingContext = model;
            SetBinding(TitleProperty, new Binding(nameof(EditionEvenementViewModel.Title)));
        }
    }
}
