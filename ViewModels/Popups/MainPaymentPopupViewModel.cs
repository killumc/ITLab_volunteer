using MainComponents.Popups;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using test2.Utilities;

namespace test2.ViewModels.Popups
{
    public partial class MainPaymentPopupViewModel(CloseNavigationService<ModalNavigationStore> closeNavigation, SaveDataService saveService ) : BasePopupViewModel(closeNavigation)
    {
        [ObservableProperty] private string donationAmount;

        [RelayCommand]
        private void Loaded() => DonationAmount = $"{saveService.Donate.DonationAmount ?? 0} ₽";

        [RelayCommand]
        private void CardPopupOpen() => saveService.NextPopup = SaveDataService.PopupType.card;

        [RelayCommand]
        private void QRPopupOpen() => saveService.NextPopup = SaveDataService.PopupType.QR;

        [RelayCommand]
        private void ClosePopup() => saveService.NextPopup = SaveDataService.PopupType.exit;
    }
}
