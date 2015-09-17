using System;
using System.Collections.Generic;
using System.Linq;

using CSharpGeckoBoardPush.Widgets;

using WebAnchor.RequestFactory;
using WebAnchor.RequestFactory.Transformation;
using WebAnchor.RequestFactory.Transformation.Transformers.Default;

namespace CSharpGeckoBoardPush.Factory
{
    public class WidgetKeyTransformer : IParameterListTransformer
    {
        public IEnumerable<Parameter> TransformParameters(IEnumerable<Parameter> parameters, ParameterTransformContext parameterTransformContext)
        {
            var param = parameters.Single(x => x.ParameterType == ParameterType.Content);

            var widget = ((Widget)param.ParameterValue);
            var value = widget.WidgetKey;
            var list = parameters.ToList();
            list.Add(new Parameter(null, value, ParameterType.Route) { Name = "widget-key" });

            param.Value = new { Data = widget.CreateData() }.ToDictionary();
            return list;
        }

        public void ValidateApi(Type type)
        {
        }
    }
}