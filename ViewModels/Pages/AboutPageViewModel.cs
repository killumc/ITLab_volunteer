using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;

namespace test2.ViewModels.Pages
{
    public partial class AboutPageViewModel(NavigationService<MainPageViewModel> MainViewNavigationService) : ObservableObject
    {
        [ObservableProperty] private object currentPageViewModel;
         private int indexCurrentPage=0;

        public List<string> ListPagesViewModel { get; set; }

        

        [RelayCommand]
        private void MainViewNavigation() => MainViewNavigationService.Navigate();

        [RelayCommand]
        private void Loaded()
        {
            ListPagesViewModel = ["/Resources/Images/aboutView/Frame 1.png", "/Resources/Images/aboutView/Frame 2.png", "/Resources/Images/aboutView/Frame 3.png", "/Resources/Images/aboutView/Page4.png", "/Resources/Images/aboutView/Page5.png",];
            indexCurrentPage = 0;
            CurrentPageViewModel = ListPagesViewModel[indexCurrentPage];

        }

        [RelayCommand]
        private void NextPage()
        {
            if (indexCurrentPage + 1 <= ListPagesViewModel.Count()-1)
            {
                indexCurrentPage++;
                CurrentPageViewModel = ListPagesViewModel[indexCurrentPage];

            }
        }

        [RelayCommand]
        private void PreviousPage()
        {
            if(indexCurrentPage >0)
            {
                indexCurrentPage--;
                CurrentPageViewModel = ListPagesViewModel[indexCurrentPage];
            }
        }
    }
}
