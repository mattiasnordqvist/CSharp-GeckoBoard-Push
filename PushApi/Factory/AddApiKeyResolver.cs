using System;
using System.Collections.Generic;
using System.Linq;

using WebAnchor.RequestFactory;
using WebAnchor.RequestFactory.Transformation;

namespace CSharpGeckoBoardPush.Factory
{
    internal class AddApiKeyResolver : IParameterListTransformer
    {
        private readonly string _apiKey;

        public AddApiKeyResolver(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void Resolve(Parameter parameter)
        {
            if (parameter.ParameterType == ParameterType.Content)
            {
                ((IDictionary<string, object>)parameter.Value).Add("api_key", _apiKey);
                ((IDictionary<string, object>)parameter.Value).Remove("WidgetKey");
            }
        }

        public IEnumerable<Parameter> TransformParameters(IEnumerable<Parameter> parameters, ParameterTransformContext parameterTransformContext)
        {
            Resolve(parameters.Single(x => x.ParameterType == ParameterType.Content));
            return parameters;
        }

        public void ValidateApi(Type type)
        {
        }
    }
}