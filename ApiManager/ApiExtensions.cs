using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace test2.ApiManager
{
    public static class ApiExtensions
    {
        public static async Task TryExecuteRequest<T>(this Task<T> task, Action<T> onSuccess, ILogger logger)
        {
            try
            {
                onSuccess(await task);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }

        public static async Task<string> LoadImageAndGetPath(this IApi client, ILogger logger, string url, string localPath = "AllImages")
        {
            if (string.IsNullOrEmpty(url)) return string.Empty;
        if (File.Exists(Path.GetFullPath(url))) return url;
        var filename = url.Replace('/', '_');
        if (string.IsNullOrEmpty(filename)) return string.Empty;

        var imageFile = Path.GetFullPath(Path.Combine(localPath, filename));

        if (!Directory.Exists(localPath)) Directory.CreateDirectory(localPath);
        if (File.Exists(imageFile)) return imageFile;

        HttpResponseMessage? response = null;
        await client
            .LoadImage(url.TrimStart('/'))
            .TryExecuteRequest(r => response = r, logger);
        if (response is null) return string.Empty;
        if (File.Exists(imageFile)) return imageFile;
        await using var fs = new FileStream(
            imageFile,
            FileMode.CreateNew);
        await response.Content.CopyToAsync(fs);
        return imageFile;
        }
    }

}
