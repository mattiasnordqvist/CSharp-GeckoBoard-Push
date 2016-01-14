using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using WebAnchor;
using WebAnchor.RequestFactory;
using WebAnchor.RequestFactory.Transformation;

namespace CSharpGeckoBoardPush.Factory
{
    internal class GeckoApiSettings : ApiSettings
    {
        private readonly string _apiKey;

        public GeckoApiSettings(string apiKey)
        {
            _apiKey = apiKey;
            ContentSerializer = CreateContentSerializer();
            ParameterListTransformers = CreateParameterListTransformers().ToList();
        }

        private IContentSerializer CreateContentSerializer()
        {
            return new ContentSerializer(new JsonSerializer { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        private IList<IParameterListTransformer> CreateParameterListTransformers()
        {
            var defaultList = ParameterListTransformers;
            defaultList.Add(new WidgetKeyTransformer());
            defaultList.Add(new AddApiKeyResolver(_apiKey));
            return defaultList;
        }
    }
}