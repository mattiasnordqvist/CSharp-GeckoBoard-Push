namespace CSharpGeckoBoardPush
{
    /// <summary>
    /// Expects data in the format that geckoboard expects. See https://developer.geckoboard.com/#custom-widget-types
    /// </summary>
    public class DefaultWidgetDataFactory : IWidgetDataFactory<object>
    {
        public object CreateData(object input)
        {
            return input;
        }
    }
}