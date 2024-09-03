namespace EXAM_MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            UserAppTheme = PlatformAppTheme;
        }
    }
}
