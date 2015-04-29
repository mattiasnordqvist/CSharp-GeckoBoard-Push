namespace CSharpGeckoBoardPush.Widgets.GeckOMeter
{
    public class Data
    {
        public Data(double value, double min, double max)
        {
            this.Item = value;
            this.Min = new ValueContainer(min);
            this.Max = new ValueContainer(max);
        }

        public double Item { get; set; }
        public ValueContainer Min { get; set; }
        public ValueContainer Max { get; set; }
    }
}