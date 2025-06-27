using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;

namespace test2.ViewModels.Pages
{
    public partial class MainPageViewModel(NavigationService<ProjectPageViewModel> ProjectViewNavigationService, NavigationService<AboutPageViewModel> AboutViewNavigationService) : ObservableObject
    {
        [RelayCommand] private void ProjectViewNavigation() => ProjectViewNavigationService.Navigate();
        [RelayCommand] private void AboutViewNavigation() => AboutViewNavigationService.Navigate();
    }
}