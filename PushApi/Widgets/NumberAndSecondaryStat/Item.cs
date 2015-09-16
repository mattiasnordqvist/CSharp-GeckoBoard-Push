namespace CSharpGeckoBoardPush.Widgets.NumberAndSecondaryStat
{
    public class Item
    {
        public Item(double value)
        {
            Value = value;
        }
        
        public double Value { get; set; }

        public string Text { get; set; }
    }
}