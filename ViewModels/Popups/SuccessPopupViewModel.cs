using MainComponents.Popups;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using test2.Utilities;
using test2.ViewModels.Pages;

namespace test2.ViewModels.Popups
{
    public partial class SuccessPopupViewModel(CloseNavigationService<ModalNavigationStore> closeNavigation, NavigationService<MainPageViewModel> mainViewNavigationService) : BasePopupViewModel(closeNavigation)
    {
        [RelayCommand]
        private void closePopup()
        {
            closeNavigation.Navigate();
            mainViewNavigationService.Navigate();
        }
    }
}
