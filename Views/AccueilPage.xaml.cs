namespace EXAM_MAUI.Views
{
    public partial class AccueilPage : ContentPage
    {
        public AccueilPage(AccueilViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Title = "Accueil";
            BindingContext = viewModel;
            SetBinding(Page.TitleProperty, new Binding(nameof(AccueilViewModel.Title)));
        }
    }
}
