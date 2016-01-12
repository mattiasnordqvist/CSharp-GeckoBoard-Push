using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using WebAnchor.RequestFactory;
using WebAnchor.RequestFactory.HttpAttributes;
using WebAnchor.RequestFactory.Transformation.Transformers;
using WebAnchor.RequestFactory.Transformation.Transformers.Default;

namespace CSharpGeckoBoardPush.Factory
{
    [BaseLocation("/v1/send")]
    internal interface IGeckoApi : IDisposable
    {
        [Post("/{widget-key}/")]
        Task<HttpResponseMessage> Push<T>([Content] [AsDictionary] T widget) where T : WidgetData;
    }
}