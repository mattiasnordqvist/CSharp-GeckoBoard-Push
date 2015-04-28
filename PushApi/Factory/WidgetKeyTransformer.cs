using System.Collections.Generic;
using System.Linq;

using CSharpGeckoBoardPush.Widgets;

using WebAnchor.RequestFactory;

namespace CSharpGeckoBoardPush.Factory
{
    public class WidgetKeyTransformer : IParameterListTransformer
    {
        public IEnumerable<Parameter> TransformParameters(IEnumerable<Parameter> parameters, ParameterTransformContext parameterTransformContext)
        {
            var param = parameters.Single(x => x.ParameterType == ParameterType.Content);

            var value = ((Widget)param.ParameterValue).WidgetKey;
            var list = parameters.ToList();
            list.Add(new Parameter(null, value, ParameterType.Route) { Name = "widget-key" });

            return list;
        }
    }
}