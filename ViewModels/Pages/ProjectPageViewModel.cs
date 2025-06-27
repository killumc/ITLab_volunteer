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
        IApi Api, 
        NavigationService<SelectedProjectPageViewModel> SelectedProjectNavigationService,
        SelectedCardService selectedCardS) : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<CardModel> cards = [];

        [RelayCommand] private void MainViewNavigation() => MainViewNavigationService.Navigate();
        [RelayCommand]private void SelectedProjectNavigation(CardModel selectedCard)
        {
            selectedCardS.SelectedCard=selectedCard;
            SelectedProjectNavigationService.Navigate();
        }

        [RelayCommand] private void Loaded()
        {
            SetCard();
        }

        async void SetCard()
        {
            //var cardsList = await Api.GetCardsAsync();

            //try
            //{
            //    foreach (var card in cardsList)
            //    {

            //        if(card.Id%2 == 0 ) card.ItsRed=true;
            //        else card.ItsRed = false;

            //        cards.Add(card);
            //    }
            //}
            //catch (ApiException ex)
            //{
            //    Debug.WriteLine($"API Error: {ex.StatusCode} - {ex.Message}");
            //}

            var json = File.ReadAllText("CardsInfo.json");
            List<CardModel> cardsList = JsonSerializer.Deserialize<List<CardModel>>(json);

            foreach (var card in cardsList)
            {

                if (card.Id % 2 == 0) card.ItsRed = true;
                else card.ItsRed = false;

                cards.Add(card);
            }


        }
    }
}
