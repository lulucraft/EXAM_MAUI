namespace EXAM_MAUI.Views
{
    public partial class AgentPage : ContentPage
    {
        public AgentPage(AgentViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Title = "Agents";
            BindingContext = viewModel;
            SetBinding(TitleProperty, new Binding(nameof(AgentViewModel.Title)));
        }
    }
}
