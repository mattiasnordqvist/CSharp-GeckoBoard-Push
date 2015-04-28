namespace CSharpGeckoBoardPush.Widgets.PieChart
{
    public class Item
    {
        public Item(string label, double value)
        {
            Label = label;
            Value = value;
        }

        public string Color { get; set; }
        
        public double Value { get; set; }

        public string Label { get; set; }
    }
}