namespace EXAM_MAUI.Views
{
    public partial class EditionEvenementPage : ContentPage
    {
        public EditionEvenementPage(EditionEvenementViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Title = "Edition évenement";
            BindingContext = viewModel;
            SetBinding(Page.TitleProperty, new Binding(nameof(EditionEvenementViewModel.Title)));
        }
    }
}
