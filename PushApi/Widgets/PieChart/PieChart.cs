namespace CSharpGeckoBoardPush.Widgets.PieChart
{
    public class PieChart : Widget
    {
        public PieChart(string widgetKey)
            : base(widgetKey)
        {
            Data = new Data();
        }

        public Data Data { get; set; }
  }
}