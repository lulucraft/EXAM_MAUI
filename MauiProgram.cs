﻿using EXAM_MAUI.Context.Models;
using EXAM_MAUI.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
            builder.Services.AddSingleton<SearchViewModel>();
            builder.Services.AddSingleton<SearchPage>();
            builder.Services.AddSingleton<SettingsViewModel>();
            builder.Services.AddSingleton<SettingsPage>();
            builder.Services.AddTransient<NewEventViewModel>();
            builder.Services.AddTransient<NewEventPage>();

            builder.Services.AddSingleton<IInviteService, InviteService>();
            builder.Services.AddTransient<AccueilViewModel>();
            builder.Services.AddTransient<AccueilPage>();
            builder.Services.AddSingleton<AgentViewModel>();
            builder.Services.AddSingleton<AgentPage>();

            // Ajouter la configuration des secrets utilisateur
            var configuration = new ConfigurationBuilder()
                .Build();

            builder.Configuration.AddConfiguration(configuration);

            // Configurer le contexte de base de données
            object dbContext = builder.Services.AddDbContext<ArkoneLajContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Enregistrer le service de configuration pour l'injection de dépendances
            builder.Services.AddSingleton<IConfiguration>(configuration);
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
