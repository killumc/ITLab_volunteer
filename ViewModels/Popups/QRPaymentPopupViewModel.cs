using MainComponents.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using test2.Utilities;
using test2.ViewModels.Pages;

namespace test2.ViewModels.Popups
{
    public partial class QRPaymentPopupViewModel(CloseNavigationService<ModalNavigationStore> closeNavigation, SaveDataService saveService, NavigationService<MainPageViewModel> mainViewNavigationService) : BasePopupViewModel(closeNavigation)
    {
        [ObservableProperty] private string donationAmount;

        [RelayCommand]
        private void Loaded() => DonationAmount = $"{saveService.Donate.DonationAmount ?? 0} ₽";

        [RelayCommand]
        private void MainOpen() => saveService.NextPopup = SaveDataService.PopupType.main;

        [RelayCommand]
        private void GoMainView()
        {
            saveService.NextPopup = SaveDataService.PopupType.exit;
            mainViewNavigationService.Navigate();
        }
    }
}
