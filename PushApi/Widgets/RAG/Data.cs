using System.Collections.Generic;

namespace CSharpGeckoBoardPush.Widgets.RAG
{
    public class Data
    {
        public Data()
        {
            Item = new List<RagItem>();
        }

        public List<RagItem> Item { get; set; }
        public string Type { get; set; }
        
    }
}