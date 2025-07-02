using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Services.ServiceCollectionExtensions;
using MvvmNavigationLib.Stores;
using test2.ApiManager;
using test2.Utilities;
using test2.ViewModels;
using test2.ViewModels.Pages;

using test2.ViewModels.Popups;

namespace test2.HostBuilders
{
    public static class BuildSaveDataExtension
    {
        public static IHostBuilder BuildSaveData(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<SaveDataService>();
                services.AddSingleton<PaymentSimulator>();

                services.AddSingleton<LoadingPopupViewModel>();
                services.AddSingleton<ErrorPopupViewModel>();
                services.AddSingleton<MainPaymentPopupViewModel>();
                services.AddSingleton<QRPaymentPopupViewModel>();
                services.AddSingleton<CardPaymentPopupViewModel>();
                services.AddSingleton<SuccessPopupViewModel>();

            });

            return builder;
        }
    }
}