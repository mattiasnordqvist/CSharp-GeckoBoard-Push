using System;
using System.Net.Http;

using WebAnchor;

namespace CSharpGeckoBoardPush.Factory
{
    public class GeckoApiFactory
    {
        public IGeckoApi Create(GeckoApiSettings settings, string host = null, HttpClient client = null)
        {
            var h = host ?? "https://push.geckoboard.com";
            var api = Api.For<IGeckoApi>(client ?? new HttpClient { BaseAddress = new Uri(h) }, settings);
            return api;
        }

        public IGeckoApi Create(string apiKey, string host = null, HttpClient client = null)
        {
            return Create(new GeckoApiSettings(apiKey), host, client);
        }
    }
}