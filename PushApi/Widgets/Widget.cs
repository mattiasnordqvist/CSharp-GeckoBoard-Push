using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharpGeckoBoardPush.Widgets
{
    public abstract class Widget
    {
        protected Widget(string widgetKey)
        {
            WidgetKeyGuard(widgetKey);
            WidgetKey = widgetKey;
        }

        protected void NullGuard(object o, string paramName = null)
        {
            if (o != null)
            {
                return;
            }

            if (paramName == null)
            {
                throw new ArgumentNullException();
            }

            throw new ArgumentNullException(paramName);
        }

        private void WidgetKeyGuard(string widgetKey)
        {
            NullGuard(widgetKey, "widgetKey");

            const string Regex = "^[0-9a-f]{5,6}-[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$";

            if (!new Regex(Regex).IsMatch(widgetKey))
            {
                throw new ArgumentException("widgetKey has wrong format", "widgetKey");
            }
        }

        public string WidgetKey { get; set; }

        public abstract object CreateData();
    }
}