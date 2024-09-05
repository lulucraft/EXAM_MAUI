using EXAM_MAUI.Context.Models;
using EXAM_MAUI.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace EXAM_MAUI
{
    public static partial class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                   .UseMauiCommunityToolkit()
                   .UseMauiCommunityToolkitMarkup()
                   .ConfigureFonts(fonts =>
                   {
                       fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                       fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
                       fonts.AddFont("MaterialDesign-Webfont.ttf", "MaterialDesignIcons");
                       fonts.AddFont("FontAwesome-Solid900.ttf", "FontAwesomeIcons");
                   });

            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            builder.Services.AddSingleton<IInviteService, InviteService>();
            builder.Services.AddSingleton<IEvenementService, EvenementService>();
            builder.Services.AddSingleton<AccueilViewModel>();
            builder.Services.AddSingleton<AccueilPage>();
            builder.Services.AddTransient<AgentViewModel>();
            builder.Services.AddTransient<AgentPage>();
            builder.Services.AddSingleton<OrganisateurViewModel>();
            builder.Services.AddSingleton<OrganisateurPage>();
            builder.Services.AddTransient<EditionEvenementViewModel>();
            builder.Services.AddTransient<EditionEvenementPage>();
            builder.Services.AddTransient<EditionInviteViewModel>();
            builder.Services.AddTransient<EditionInvitePage>();
            builder.Services.AddTransient<FicheStatViewModel>();
            builder.Services.AddTransient<FicheStatPage>();

            // Ajouter la configuration des secrets utilisateur
            var configuration = new ConfigurationBuilder()
                .Build();

            builder.Configuration.AddConfiguration(configuration);

            // Configurer le contexte de base de données
            //object dbContext = builder.Services.AddDbContext<ArkoneLajContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            object dbContext = builder.Services.AddDbContext<ArkoneLajContext>(ServiceLifetime.Transient);

            // Enregistrer le service de configuration pour l'injection de dépendances
            builder.Services.AddSingleton<IConfiguration>(configuration);
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
