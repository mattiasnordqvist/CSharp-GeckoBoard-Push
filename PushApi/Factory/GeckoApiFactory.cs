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
                h,
                new HttpRequestFactory(
                    new ContentSerializer(
                        new JsonSerializer { ContractResolver = new CamelCasePropertyNamesContractResolver() })),
                configure: x =>
                    {
                    ((HttpRequestFactory)x.HttpRequestBuilder).DefaultParameterListTransformers.Add(new WidgetKeyTransformer());
                    ((HttpRequestFactory)x.HttpRequestBuilder).DefaultParameterResolvers.Add(new AddApiKeyResolver(apiKey));
                });

            return api;
        }
    }
}