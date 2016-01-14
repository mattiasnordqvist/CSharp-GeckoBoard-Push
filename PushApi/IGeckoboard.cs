using System;

namespace CSharpGeckoBoardPush
{
    public interface IGeckoboard : IDisposable
    {
        IWidget<object> GetWidget(string widgetKey);

        IWidget<TInput> GetWidget<TFactory, TInput>(string widgetKey, TFactory widgetDataFactory)
            where TFactory : IWidgetDataFactory<TInput>;

        IWidget<TInput> GetWidget<TFactory, TInput>(string widgetKey)
            where TFactory : IWidgetDataFactory<TInput>, new();
    }
}