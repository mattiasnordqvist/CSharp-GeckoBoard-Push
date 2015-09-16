using System.Linq;

namespace CSharpGeckoBoardPush.Widgets.NumberAndSecondaryStat
{
    public class NumberAndSecondaryStat : Widget
    {
        public NumberAndSecondaryStat(string widgetKey, double value, string text = null)
            : base(widgetKey)
        {
            Data = new Data(value);
            Data.Item.First().Text = text;
        }

        public Data Data { get; set; }

        public override object CreateData()
        {
            return Data;
        }
  }
}