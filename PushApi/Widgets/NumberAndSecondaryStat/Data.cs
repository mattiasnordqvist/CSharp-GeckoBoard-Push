using System.Collections.Generic;

namespace CSharpGeckoBoardPush.Widgets.NumberAndSecondaryStat
{
    public class Data
    {
        public Data(double value)
        {
            Item = new List<Item> { new Item(value) };
        }

        public List<Item> Item { get; set; }
    }
}