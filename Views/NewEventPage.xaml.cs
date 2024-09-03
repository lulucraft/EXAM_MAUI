namespace EXAM_MAUI.Views
{
    public partial class NewEventPage : ContentPage
    {
        public NewEventPage(NewEventViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Title = "New Event";
            BindingContext = viewModel;
        }

        protected override bool OnBackButtonPressed() => false;
    }
}
