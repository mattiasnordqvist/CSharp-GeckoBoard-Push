namespace CSharpGeckoBoardPush.Widgets
{
    public class Widget : WidgetBase
    {
        private readonly object _data;

        public Widget(string widgetKey, object data)
            : base(widgetKey)
        {
            _data = data;
        }

        public override object CreateData()
        {
            return _data;
        }
    }
}