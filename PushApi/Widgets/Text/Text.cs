namespace CSharpGeckoBoardPush.Widgets.Text
{
    public class Text : Widget
    {
        public Text(string widgetKey)
            : base(widgetKey)
        {
            Data = new Data();
        }

        public Data Data { get; set; }

        public override object CreateData()
        {
            return Data;
        }
    }
}
