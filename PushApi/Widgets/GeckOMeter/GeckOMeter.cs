namespace CSharpGeckoBoardPush.Widgets.GeckOMeter
{
    public class GeckOMeter : Widget
    {
        public GeckOMeter(string widgetKey)
            : base(widgetKey)
        {
            Data = new Data(0, 0, 0);
        }

        public Data Data { get; set; }
    }
}
