using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Microsoft.Extensions.DependencyInjection;
using test2.ApiManager;
using test2.Models;
using test2.Utilities;
using Refit;
using System.Diagnostics;

namespace test2.ViewModels.Pages
{
    public partial class ProjectPageViewModel(NavigationService<MainPageViewModel> MainViewNavigationService , 
        NavigationService<SelectedProjectPageViewModel> SelectedProjectNavigationService,
        SaveDataService saveDataS) : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<CardModel> cards = [];

        [RelayCommand] private void MainViewNavigation() => MainViewNavigationService.Navigate();
        [RelayCommand]private void SelectedProjectNavigation(CardModel selectedCard)
        {
            saveDataS.SelectedCard=selectedCard;
            SelectedProjectNavigationService.Navigate();
        }

        [RelayCommand]
        private async Task Loaded()
        {
            await saveDataS.DataLoaded;
            SetCard();
        }

        private void SetCard()
        {
            Cards.Clear();
            foreach (var card in saveDataS.AllProject)
                Cards.Add(card);
        }
    }
}
