using MainComponents.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using test2.Utilities;

namespace test2.ViewModels.Popups
{
    public partial class PaymentPopupViewModel(CloseNavigationService<ModalNavigationStore> closeNavigation,
        SaveDataService saveService,
        MainPaymentPopupViewModel mainPayment,
        CardPaymentPopupViewModel cardPayment,
        QRPaymentPopupViewModel qrPayment,
        LoadingPopupViewModel load,
        ErrorPopupViewModel error
       ): BasePopupViewModel(closeNavigation)
    {
        

        [ObservableProperty] private object currentPopupViewModel;

        [RelayCommand]
        private void Loaded()
        {
            CurrentPopupViewModel = mainPayment;
            saveService.PopupChanged += OnPopupChanged;
        }

        private void OnPopupChanged()
        {
            switch (saveService.NextPopup)
            {
                case SaveDataService.PopupType.main:
                    CurrentPopupViewModel = mainPayment;
                    break;
                case SaveDataService.PopupType.card:
                    CurrentPopupViewModel = cardPayment;
                    break;
                case SaveDataService.PopupType.QR:
                    CurrentPopupViewModel = qrPayment;
                    break;
                case SaveDataService.PopupType.load:
                    CurrentPopupViewModel = load;
                    break;
                case SaveDataService.PopupType.error:
                    CurrentPopupViewModel = error;
                    break;
                case SaveDataService.PopupType.exit:
                    closeNavigation.Navigate();
                    break;
            }
        }

    }
}
