namespace EXAM_MAUI.Views
{
    public partial class AgentPage : ContentPage
    {
        public AgentPage(AccueilViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Title = "Agents";
            BindingContext = viewModel;
            SetBinding(Page.TitleProperty, new Binding(nameof(AgentViewModel.Title)));
        }
    }
}
