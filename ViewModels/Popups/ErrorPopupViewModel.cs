﻿using MainComponents.Popups;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace test2.ViewModels.Popups
{
    public partial class ErrorPopupViewModel(CloseNavigationService<ModalNavigationStore> closeNavigation) : BasePopupViewModel(closeNavigation)
    {
        [RelayCommand]
        private void ClosePopup() => closeNavigation.Navigate();
    }
}
