using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MainComponents.Popups;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test2.Utilities;

namespace test2.ViewModels.Popups
{
    public partial class CardPaymentPopupViewModel(CloseNavigationService<ModalNavigationStore> closeNavigation, SaveDataService saveService) : BasePopupViewModel(closeNavigation)
    {
        [ObservableProperty] private string donationAmount;

        [RelayCommand]
        private void Loaded() => DonationAmount = $"{saveService.Donate.DonationAmount ?? 0} ₽";

        [RelayCommand]
        private void MainOpen() => saveService.NextPopup = SaveDataService.PopupType.main;
    }
}
