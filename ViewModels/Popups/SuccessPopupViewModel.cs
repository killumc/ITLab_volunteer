using MainComponents.Popups;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2.ViewModels.Popups
{
    public partial class SuccessPopupViewModel(CloseNavigationService<ModalNavigationStore> closeNavigation) : BasePopupViewModel(closeNavigation)
    {
    }
}
