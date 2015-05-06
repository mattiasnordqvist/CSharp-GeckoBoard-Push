using System.Collections.Generic;

namespace CSharpGeckoBoardPush.Widgets.RAG
{
    public class Data
    {
        public Data()
        {
            Item = new List<Item>();
            //Type = "reverse";
            
        }

        public List<Item> Item { get; set; }
        public string Type { get; set; }
        
    }
}