using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MainComponents.Popups;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using test2.Utilities;

namespace test2.ViewModels.Popups
{
    public partial class CardPaymentPopupViewModel(CloseNavigationService<ModalNavigationStore> closeNavigation, SaveDataService saveService, PaymentSimulator simulator) : BasePopupViewModel(closeNavigation)
    {
        [ObservableProperty] private string donationAmount;

        [RelayCommand]
        private async Task Loaded()
        {
            DonationAmount = $"{saveService.Donate.DonationAmount ?? 0} ₽";
            await Task.Delay(1500);
            saveService.NextPopup = SaveDataService.PopupType.load;
            bool result = simulator.ImitatePayment(saveService.Donate.Project.Title, saveService.Donate.DonationAmount);
            await Task.Delay(1500);

            saveService.NextPopup = result ? SaveDataService.PopupType.success : SaveDataService.PopupType.error;

        }

        [RelayCommand]
        private void MainOpen() => saveService.NextPopup = SaveDataService.PopupType.main;

        
    }
}

