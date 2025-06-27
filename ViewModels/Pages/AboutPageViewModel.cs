using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using test2.ViewModels.Pages.AboutPages;

namespace test2.ViewModels.Pages
{
    public partial class AboutPageViewModel(NavigationService<MainPageViewModel> MainViewNavigationService, 
        About1PageViewModel about1,
        About2PageViewModel about2,
        About3PageViewModel about3,
        About4PageViewModel about4,
        About5PageViewModel about5) : ObservableObject
    {
        [ObservableProperty] private object currentPageViewModel;
         private int indexCurrentPage=0;

        public List<object> ListPagesViewModel { get; set; }

        

        [RelayCommand]
        private void MainViewNavigation() => MainViewNavigationService.Navigate();

        [RelayCommand]
        private void Loaded()
        {
            ListPagesViewModel = [about1,about2, about3, about4, about5];
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
