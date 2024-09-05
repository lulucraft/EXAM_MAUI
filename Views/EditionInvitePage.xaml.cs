namespace EXAM_MAUI.Views
{
    public partial class EditionInvitePage : ContentPage
    {
        public EditionInvitePage(EditionInviteViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Title = "Edition Invité";
            BindingContext = viewModel;
            SetBinding(TitleProperty, new Binding(nameof(EditionInviteViewModel.Title)));
        }
    }
}
