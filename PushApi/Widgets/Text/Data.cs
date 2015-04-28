using System.Collections.Generic;

namespace CSharpGeckoBoardPush.Widgets.Text
{
    public class Data
    {
        public Data()
        {
            this.Item = new List<Item>();
        }

        public List<Item> Item { get; set; }
    }
}