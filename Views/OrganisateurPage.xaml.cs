namespace EXAM_MAUI.Views
{
    public partial class OrganisateurPage : ContentPage
    {
        public OrganisateurPage(OrganisateurViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Title = "Organisateurs";
            BindingContext = viewModel;
            SetBinding(Page.TitleProperty, new Binding(nameof(OrganisateurViewModel.Title)));
        }
    }
}
