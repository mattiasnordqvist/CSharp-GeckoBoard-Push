using System.Net.Http;
using System.Threading.Tasks;

using CSharpGeckoBoardPush.Widgets;

using WebAnchor.RequestFactory;
using WebAnchor.RequestFactory.HttpAttributes;

namespace CSharpGeckoBoardPush
{
    [BaseLocation("/v1/send")]
    public interface IGeckoApi
    {
        [Post("/{widget-key}/")]
        Task<HttpResponseMessage> Push<T>([Content] T widget) where T : Widget;
    }
}