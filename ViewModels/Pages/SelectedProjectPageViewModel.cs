using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using test2.ApiManager;
using test2.Models;
using test2.Utilities;


namespace test2.ViewModels.Pages
{
    public partial class SelectedProjectPageViewModel(NavigationService<ProjectPageViewModel> projectViewNavigationService, 
        NavigationService<DonatePageViewModel> donateViewNavigationService,
        SaveDataService saveDataS): ObservableObject
    { 
        private int _idSelectedCard;
        [ObservableProperty] private CardModel? _selectedCard;
        [RelayCommand] private void ProjectViewNavigate()
        {
            projectViewNavigationService.Navigate();

        }

        [RelayCommand]
        private void DonateViewNavigate() => donateViewNavigationService.Navigate();
        [RelayCommand] 
         private void Loaded()
        {
            _idSelectedCard = saveDataS.SelectedCard.Id;
            saveDataS.DonateCard= _selectedCard;

            try
            {
                var card = saveDataS.AllProject.FirstOrDefault(c => c.Id == _idSelectedCard);
                if (card != null)
                {
                    SelectedCard = card;
                }
                else
                {
                    Debug.WriteLine("Card not found!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }



    }
}
