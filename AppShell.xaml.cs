using EXAM_MAUI.Views;
using Syncfusion.Maui.Themes;

namespace EXAM_MAUI
{
    public partial class AppShell : Shell
    {
        //[ObservableProperty]
        //public bool isDarkMode;

        public AppShell()
        {
            InitializeComponent();
            // Register the routes of the detail pages
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(AgentPage), typeof(AgentPage));
            Routing.RegisterRoute(nameof(OrganisateurPage), typeof(OrganisateurPage));
            Routing.RegisterRoute(nameof(EditionEvenementPage), typeof(EditionEvenementPage));
            Routing.RegisterRoute(nameof(EditionInvitePage), typeof(EditionInvitePage));
            Routing.RegisterRoute(nameof(FicheStatPage), typeof(FicheStatPage));
        }

        //private void OnThemeToggled(object sender, ToggledEventArgs e)
        //{
        //    if (e.Value) // Dark Mode enabled
        //    {
        //        App.Current.Resources.MergedDictionaries.Clear();
        //        App.Current.Resources.MergedDictionaries.Add(new DarkThemeColors());
        //    }
        //    else // Light Mode enabled
        //    {
        //        App.Current.Resources.MergedDictionaries.Clear();
        //        App.Current.Resources.MergedDictionaries.Add(new LightThemeColors());
        //    }
        //}

        /*private void ChangeTheme(bool isDarkMode)
        {
            if (isDarkMode)
            {
                Current.Resources.MergedDictionaries.Clear();
                Current.Resources.MergedDictionaries.Add(new DarkThemeColors());
            }
            else
            {
                Current.Resources.MergedDictionaries.Clear();
                Current.Resources.MergedDictionaries.Add(new LightThemeColors());
            }
        }*/

        private void ChangeTheme(object sender, ToggledEventArgs e)
        {
            bool isDarkMode = e.Value; // e.Value est true si le switch est activé, sinon false

            if (isDarkMode)
            {
                // Activer le mode sombre
                Application.Current!.UserAppTheme = AppTheme.Dark;
            }
            else
            {
                // Activer le mode clair
                Application.Current!.UserAppTheme = AppTheme.Light;
            }
        }
    }
}
