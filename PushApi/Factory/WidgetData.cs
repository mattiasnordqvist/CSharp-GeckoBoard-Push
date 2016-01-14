namespace CSharpGeckoBoardPush.Factory
{
    internal class WidgetData
    {
        public string WidgetKey { get; set; }

        public object Data { get; set; }

        public WidgetData(string widgetKey, object data)
        {
            WidgetKey = widgetKey;
            Data = data;
        }
    }
}