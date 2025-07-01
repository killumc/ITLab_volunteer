using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test2.Models;

namespace test2.Utilities
{
    public class ProjectService
    {
        public CardModel? SelectedCard { get; set; }
        public CardModel? DonateCard { get; set; }

        private readonly TaskCompletionSource _dataLoaded = new();
        public List<CardModel> AllProject { get; set; } = new();

        // Это Task, который можно await-ить, чтобы дождаться загрузки данных
        public Task DataLoaded => _dataLoaded.Task;

        // Метод для установки данных и сигнала о готовности
        public void SetProjects(IEnumerable<CardModel> projects)
        {
            AllProject.Clear();
            AllProject.AddRange(projects);
            _dataLoaded.TrySetResult(); 
        }
    }
}
