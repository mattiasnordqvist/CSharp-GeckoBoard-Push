namespace CSharpGeckoBoardPush.Widgets.GeckOMeter
{
    public class Data
    {
        public Data(double value, double min, double max)
        {
            Item = value;
            Min = new ValueContainer(min);
            Max = new ValueContainer(max);
        }

        public double Item { get; set; }
        public ValueContainer Min { get; set; }
        public ValueContainer Max { get; set; }
    }
}