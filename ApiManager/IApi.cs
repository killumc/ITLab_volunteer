using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using test2.Models;

namespace test2.ApiManager
{
    public interface IApi
    {
        [Get("/projects")]
        Task<ObservableCollection<ProjectApiModel>> GetCardsAsync();
    }
}
