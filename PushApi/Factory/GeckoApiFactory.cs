using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using WebAnchor;
using WebAnchor.RequestFactory;

namespace CSharpGeckoBoardPush.Factory
{
    public class GeckoApiFactory
    {
        public IGeckoApi Create(string apiKey, string host = null)
        {
            var h = host ?? "https://push.geckoboard.com";

            var api = Api.For<IGeckoApi>(
                new HttpClient(new LoggingHandler(new HttpClientHandler())){BaseAddress = new Uri(h)},
                new HttpRequestFactory(
                    new ContentSerializer(
                        new JsonSerializer { ContractResolver = new CamelCasePropertyNamesContractResolver() })), 
                configure: x =>
                    {
                    ((HttpRequestFactory)x.HttpRequestBuilder).DefaultParameterListTransformers.Add(new WidgetKeyTransformer());
                    ((HttpRequestFactory)x.HttpRequestBuilder).DefaultParameterListTransformers.Add(new AddApiKeyResolver(apiKey));
                });

            return api;
        }
    }

    public class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Request:");
            Console.WriteLine(request.ToString());
            if (request.Content != null)
            {
                Console.WriteLine(await request.Content.ReadAsStringAsync());
            }
            Console.WriteLine();

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            Console.WriteLine("Response:");
            Console.WriteLine(response.ToString());
            if (response.Content != null)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            Console.WriteLine();

            return response;
        }
    }
}