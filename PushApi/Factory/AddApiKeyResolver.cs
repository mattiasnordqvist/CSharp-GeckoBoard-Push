using System.Collections.Generic;

using WebAnchor.RequestFactory;

namespace CSharpGeckoBoardPush.Factory
{
    public class AddApiKeyResolver : IParameterResolver
    {
        private readonly string _apiKey;

        public AddApiKeyResolver(string apiKey)
        {
            this._apiKey = apiKey;
        }

        public void Resolve(Parameter parameter)
        {
            if (parameter.ParameterType == ParameterType.Content)
            {
                ((IDictionary<string, object>)parameter.Value).Add("api_key", this._apiKey);
                ((IDictionary<string, object>)parameter.Value).Remove("WidgetKey");
            }
        }
    }
}