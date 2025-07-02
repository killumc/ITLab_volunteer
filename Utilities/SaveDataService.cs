using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using test2.Models;

namespace test2.Utilities
{
    public partial class SaveDataService: ObservableObject
    {
        public enum PopupType
        {
            main,
            card,
            QR,
            load,
            error,
            success,
            exit
        }
        public CardModel? SelectedCard { get; set; }
        public CardModel? DonateCard { get; set; }
        public DonationModel? Donate { get; set; }

        public event Action? PopupChanged;

        private PopupType _nextPopup;
        public PopupType NextPopup
        {
            get => _nextPopup;
            set
            {
                if (_nextPopup != value)
                {
                    _nextPopup = value;
                    PopupChanged?.Invoke();
                }
            }
        }


        private readonly TaskCompletionSource _dataLoaded = new();
        [ObservableProperty] private List<CardModel> _allProject = new();

        // Это Task, который можно await-ить, чтобы дождаться загрузки данных
        public Task DataLoaded => _dataLoaded.Task;

        // Метод для установки данных и сигнала о готовности
        public void SetProjects(List<CardModel> projects)
        {
            AllProject.Clear();
            AllProject.AddRange(projects);
            _dataLoaded.TrySetResult(); 
        }
    }
}
