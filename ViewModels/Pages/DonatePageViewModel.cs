using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using test2.Utilities;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MvvmNavigationLib.Stores;
using test2.Models;
using test2.ViewModels.Popups;

namespace test2.ViewModels.Pages
{
    public partial class DonatePageViewModel(SaveDataService saveDataS, GoBackNavigationService<NavigationStore> backNavigation, NavigationService<PaymentPopupViewModel> paymentNavigationService) : ObservableObject
    {
        private const int MaxDonate = 999_000_000;
        private const int MinDonate = 10;

        [ObservableProperty]
        private int? _selectedSum = null;
        [ObservableProperty] private string _ownSumDonate = "";
        [ObservableProperty]
        private List<CardModel> _cards = [];
        [ObservableProperty]
        private CardModel selectedCard;


        [RelayCommand]
        private void backPageNavigation() => backNavigation.Navigate();

        [RelayCommand]
        private void OpenPaymentPopup()
        {
            saveDataS.Donate = new DonationModel();
            if (SelectedCard == null || ActualSum == null) return;
            saveDataS.Donate.Project = SelectedCard;
            saveDataS.Donate.DonationAmount = ActualSum;
            paymentNavigationService.Navigate();
        }
        [RelayCommand] private void Add1() => TryAddDigit('1');
        [RelayCommand] private void Add2() => TryAddDigit('2');
        [RelayCommand] private void Add3() => TryAddDigit('3');
        [RelayCommand] private void Add4() => TryAddDigit('4');
        [RelayCommand] private void Add5() => TryAddDigit('5');
        [RelayCommand] private void Add6() => TryAddDigit('6');
        [RelayCommand] private void Add7() => TryAddDigit('7');
        [RelayCommand] private void Add8() => TryAddDigit('8');
        [RelayCommand] private void Add9() => TryAddDigit('9');
        [RelayCommand] private void Add0() => TryAddDigit('0');
        [RelayCommand] private void Delete()
        {
            if(OwnSumDonate!= String.Empty)OwnSumDonate = OwnSumDonate.Remove(OwnSumDonate.Length - 1);
        }

        [RelayCommand]
        private async Task Loaded()
        {
            await saveDataS.DataLoaded;
            Cards.Add(new CardModel(){Title = "Без проекта", Id = 0});
            Cards.AddRange(saveDataS.AllProject);
            SelectedCard = Cards[0];
        }
        public int? ActualSum
        {
            get
            {
                if (SelectedSum != null)
                    return SelectedSum;
                if (int.TryParse(OwnSumDonate, out var value) && value >= MinDonate && value <= MaxDonate)
                    return value;
                return null;
            }
        }
        partial void OnSelectedSumChanged(int? value)
        {
            if (value != null)
                OwnSumDonate = "";
        }
        private void TryAddDigit(char digit)
        {
            if (OwnSumDonate == "0") OwnSumDonate = "";

            string newSum = OwnSumDonate + digit;
            if (long.TryParse(newSum, out long value) && value <= MaxDonate)
            {
                OwnSumDonate = newSum;
            }
        }
        partial void OnOwnSumDonateChanged(string value)
        {
            SelectedSum = null;
        }
    }
}
