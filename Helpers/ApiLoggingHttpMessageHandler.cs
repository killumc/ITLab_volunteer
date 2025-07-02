using System.Net.Http;
using Serilog;

namespace test2.Helpers
{
    public class ApiLoggingHttpMessageHandler(ILogger logger) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                //var content = (request.Content as HttpContent).ReadAsStringAsync().Result;
                return await base.SendAsync(request, cancellationToken);
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
                return new HttpResponseMessage{Content = new StringContent(string.Empty)};
            }
        }
    }
}