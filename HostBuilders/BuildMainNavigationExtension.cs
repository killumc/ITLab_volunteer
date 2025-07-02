using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Services.ServiceCollectionExtensions;
using MvvmNavigationLib.Stores;
using test2.ApiManager;
using test2.Models;
using test2.Utilities;
using test2.ViewModels;
using test2.ViewModels.Pages;


namespace test2.HostBuilders
{
    public static class BuildMainNavigationExtension
    {
        public static IHostBuilder BuildMainNavigation(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<NavigationStore>();
                services.AddUtilityNavigationServices<NavigationStore>();
                services.AddNavigationService<MainPageViewModel, NavigationStore>();

                services.AddNavigationService<ProjectPageViewModel, NavigationStore>(s=>
                new ProjectPageViewModel(s.GetRequiredService<NavigationService<MainPageViewModel>>(),
                    s.GetRequiredService<NavigationService<SelectedProjectPageViewModel>>(),
                    s.GetRequiredService<SaveDataService>()));

                services.AddNavigationService<SelectedProjectPageViewModel, NavigationStore>();

                services.AddNavigationService<AboutPageViewModel, NavigationStore>(s =>
                    new AboutPageViewModel(s.GetRequiredService<NavigationService<MainPageViewModel>>()));

                services.AddNavigationService<DonatePageViewModel, NavigationStore>();

            });

            return builder;
        }
    }
}