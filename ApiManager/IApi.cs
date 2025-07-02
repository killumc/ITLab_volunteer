using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Refit;
using Serilog;
using test2.Models;

namespace test2.ApiManager
{
    public interface IApi
    {
        [Get("/projects")]
        Task<List<ProjectApiModel>> GetCardsAsync();

        [Get("/{**imageId}")]
        [QueryUriFormat(UriFormat.Unescaped)]
        Task<HttpResponseMessage> LoadImage(string imageId);


    }
}
