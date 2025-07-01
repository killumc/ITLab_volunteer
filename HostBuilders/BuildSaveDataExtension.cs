using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Services.ServiceCollectionExtensions;
using MvvmNavigationLib.Stores;
using test2.ApiManager;
using test2.Utilities;
using test2.ViewModels;
using test2.ViewModels.Pages;
using test2.ViewModels.Pages.AboutPages;

namespace test2.HostBuilders
{
    public static class BuildSaveDataExtension
    {
        public static IHostBuilder BuildSaveData(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<ProjectService>();
                services.AddSingleton<About1PageViewModel>();
                services.AddSingleton<About2PageViewModel>();
                services.AddSingleton<About3PageViewModel>();
                services.AddSingleton<About4PageViewModel>();
                services.AddSingleton<About5PageViewModel>();

            });

            return builder;
        }
    }
}