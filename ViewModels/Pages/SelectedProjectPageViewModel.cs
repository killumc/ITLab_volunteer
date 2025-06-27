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
    public partial class SelectedProjectPageViewModel(NavigationService<ProjectPageViewModel> ProjectViewNavigationService, 
        SelectedCardService saveCard,
        IApi Api): ObservableObject
    { 
        private int idSelectedCard;

        [ObservableProperty] private ProjectApiModel selectedCard = new ProjectApiModel();
        [RelayCommand] private void ProjectViewNavigate() => ProjectViewNavigationService.Navigate();

        [RelayCommand]
        async void Loaded()
        {
            idSelectedCard = saveCard.SelectedCard.Id;
            Debug.WriteLine(idSelectedCard);

            var cardsList = await Api.GetCardsAsync();

            try
            {
                var card = cardsList.FirstOrDefault(c => c.Id == idSelectedCard);
                if (card != null)
                {
                    card.Description = ReplaceTags(card.Description);
                    SelectedCard = card;

                    Debug.WriteLine(selectedCard.Title);
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


        public static string ReplaceTags(string html)
        {
            if (string.IsNullOrEmpty(html))
                return html;

            string result = Regex.Replace(html, @"<br>", "\n", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"<\/?div>", "", RegexOptions.IgnoreCase);
            //result = Regex.Replace(html, @"&nbsp", "\u00A0", RegexOptions.IgnoreCase);

            return result;
        }

    }
}
