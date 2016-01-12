using System;

namespace CSharpGeckoBoardPush
{
    public interface IGeckoboard : IDisposable
    {
        Widget<DefaultWidgetDataFactory, object> GetWidget(string widgetKey);

        Widget<TFactory, TInput> GetWidget<TFactory, TInput>(string widgetKey, TFactory widgetDataFactory)
            where TFactory : IWidgetDataFactory<TInput>;

        Widget<TFactory, TInput> GetWidget<TFactory, TInput>(string widgetKey)
            where TFactory : IWidgetDataFactory<TInput>, new();
    }
}