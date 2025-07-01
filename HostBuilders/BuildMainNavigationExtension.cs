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
using test2.ViewModels.Pages.AboutPages;

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
                    s.GetRequiredService<ProjectService>()));

                services.AddNavigationService<SelectedProjectPageViewModel, NavigationStore>();

                services.AddNavigationService<AboutPageViewModel, NavigationStore>(s =>
                    new AboutPageViewModel(s.GetRequiredService<NavigationService<MainPageViewModel>>(),
                        s.GetRequiredService<About1PageViewModel>(),
                        s.GetRequiredService<About2PageViewModel>(),
                        s.GetRequiredService<About3PageViewModel>(),
                        s.GetRequiredService<About4PageViewModel>(),
                        s.GetRequiredService<About5PageViewModel>()));

                services.AddNavigationService<DonatePageViewModel, NavigationStore>();
                //services.AddNavigationService<DonatePageViewModel, NavigationStore>(s =>
                //    new DonatePageViewModel(s.GetRequiredService<GoBackNavigationService<>>()));
            });

            return builder;
        }
    }
}