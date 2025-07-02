using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using Refit;
using Serilog;
using test2.ApiManager;
using test2.Models;
using test2.Utilities;

namespace test2.ViewModels.Pages
{
    public partial class MainPageViewModel(IApi api, SaveDataService saveDataService, ILogger logger,
        NavigationService<ProjectPageViewModel> projectViewNavigationService,
        NavigationService<AboutPageViewModel> aboutViewNavigationService,
        NavigationService<DonatePageViewModel> donateViewNavigationService) : ObservableObject
    {
        private readonly string _urlBase = "http://api-sdr.itlabs.top";
        [RelayCommand] private void ProjectViewNavigation() => projectViewNavigationService.Navigate();
        [RelayCommand] private void AboutViewNavigation() => aboutViewNavigationService.Navigate();
        [RelayCommand] private void DonateViewNavigation() => donateViewNavigationService.Navigate();

        [RelayCommand]
        private async Task Loaded()
        {
            saveDataService.DonateCard = null;

            try
            {
                var cardsList = await api.GetCardsAsync();
                var projectTasks = cardsList.Select(async card => new CardModel
                {
                    Id = card.Id,
                    Title = card.Title,
                    Description = ReplaceTags(card.Description),
                    ImageSource = await api.LoadImageAndGetPath(logger, card.ImageSource),
                    ItsRed = card.Id % 2 == 0
                }).ToList();

                var projects = await Task.WhenAll(projectTasks);
                saveDataService.SetProjects(projects.ToList());

            }
            catch (ApiException ex)
            {
                Debug.WriteLine($"API Error: {ex.StatusCode} - {ex.Message}");
            }
        }

        private static string ReplaceTags(string html)
        {
            if (string.IsNullOrEmpty(html))
                return html;

            string result = Regex.Replace(html, @"<br>", "\n", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"&nbsp;", string.Empty);
            result = Regex.Replace(result, @"<.*?>", string.Empty);

            return result;
        }

        
    }
}