using System;

namespace CSharpGeckoBoardPush
{
    public interface IGeckoboard : IDisposable
    {
        IWidget<DefaultWidgetDataFactory, object> GetWidget(string widgetKey);

        IWidget<TFactory, TInput> GetWidget<TFactory, TInput>(string widgetKey, TFactory widgetDataFactory)
            where TFactory : IWidgetDataFactory<TInput>;

        IWidget<TFactory, TInput> GetWidget<TFactory, TInput>(string widgetKey)
            where TFactory : IWidgetDataFactory<TInput>, new();
    }
}