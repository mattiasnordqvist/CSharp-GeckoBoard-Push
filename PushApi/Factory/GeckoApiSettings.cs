using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using WebAnchor;
using WebAnchor.RequestFactory;
using WebAnchor.RequestFactory.Transformation;

namespace CSharpGeckoBoardPush.Factory
{
    public class GeckoApiSettings : ApiSettings
    {
        private readonly string _apiKey;

        public GeckoApiSettings(string apiKey)
        {
            _apiKey = apiKey;
        }

        public override IContentSerializer CreateContentSerializer()
        {
            return new ContentSerializer(new JsonSerializer { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        public override IList<IParameterListTransformer> CreateParameterListTransformers()
        {
            var defaultList = base.CreateParameterListTransformers();
            defaultList.Add(new WidgetKeyTransformer());
            defaultList.Add(new AddApiKeyResolver(_apiKey));
            return defaultList;
        }
    }
}