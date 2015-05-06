using CSharpGeckoBoardPush.Factory;
using CSharpGeckoBoardPush.Widgets.RAG;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new GeckoApiFactory().Create("328b406e5066317e500e2ca37cc23cdb");

            var result = api.Push(new RAG("142507-e7e9090c-574e-4e64-b58d-7d88d209d386", new RagItem("1", 1), new RagItem("1", 1), new RagItem("1", 1))).Result;
            result.EnsureSuccessStatusCode();
        }
    }
}
