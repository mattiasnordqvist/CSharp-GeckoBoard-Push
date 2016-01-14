using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpGeckoBoardPush
{
    public interface IWidget<in TInput>
    {
        Task<HttpResponseMessage> Push(TInput data);
    }
}