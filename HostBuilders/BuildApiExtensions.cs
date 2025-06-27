using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using test2.ApiManager;

namespace test2.HostBuilders
{
    public static class BuildApiExtensions
    {
        public static IHostBuilder BuildApi(this IHostBuilder builder)
        {

            builder.ConfigureServices((context, services) =>
            {
                services.AddRefitClient<IApi>(new RefitSettings
                {
                    ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    })
                }).ConfigureHttpClient(c => c.BaseAddress = new Uri("http://api-sdr.itlabs.top/api"));
            });
            return builder;
        }
    }
}