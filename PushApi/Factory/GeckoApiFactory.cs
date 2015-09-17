using System;
using System.Net.Http;

using WebAnchor;
using WebAnchor.RequestFactory;

namespace CSharpGeckoBoardPush.Factory
{
    public class GeckoApiFactory
    {
        public IGeckoApi Create(string apiKey, string host = null)
        {
            var h = host ?? "https://push.geckoboard.com";

            var settings = new GeckoApiSettings(apiKey);

            var api =
                Api.For<IGeckoApi>(
                    new HttpClient(new LoggingHandler(new HttpClientHandler())) { BaseAddress = new Uri(h) },
                    settings);
              

            return api;
        }
    }
}