namespace EXAM_MAUI.Views
{
    public partial class FicheStatPage : ContentPage
    {
        public FicheStatPage(FicheStatViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Title = "Fiche Stat";
            BindingContext = viewModel;
            SetBinding(TitleProperty, new Binding(nameof(FicheStatViewModel.Title)));
        }
    }
}
