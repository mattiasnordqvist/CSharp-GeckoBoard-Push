using System;
using System.Collections.Generic;
using System.Linq;

using WebAnchor.RequestFactory;
using WebAnchor.RequestFactory.Transformation;
using WebAnchor.RequestFactory.Transformation.Transformers.Default;

namespace CSharpGeckoBoardPush.Factory
{
    internal class WidgetKeyTransformer : IParameterListTransformer
    {
        public IEnumerable<Parameter> TransformParameters(IEnumerable<Parameter> parameters, ParameterTransformContext parameterTransformContext)
        {
            var param = parameters.Single(x => x.ParameterType == ParameterType.Content);

            var widget = (WidgetData)param.ParameterValue;
            var value = widget.WidgetKey;
            var list = parameters.ToList();
            list.Add(new Parameter(null, value, ParameterType.Route) { Name = "widget-key", Value = value });

            param.Value = new { Data = widget.Data }.ToDictionary();
            return list;
        }

        public void ValidateApi(Type type)
        {
        }
    }
}