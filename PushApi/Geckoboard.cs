using System.Net.Http;

using CSharpGeckoBoardPush.Factory;

using WebAnchor;

namespace CSharpGeckoBoardPush
{
    /// <summary>
    /// Main entry point. New up this badass with your geckoboard api key and you'll be on your way.
    /// Let your code reference declarations use IGeckoboard instead, so you can easily mock this out when testing.
    /// </summary>
    public class Geckoboard : IGeckoboard
    {
        private readonly IGeckoApi _api;

        /// <summary>
        /// Creates a proxy to an already existing geckoboard (at geckoboard.com), which you can use to push data to the boards widgets.
        /// </summary>
        /// <param name="apiKey">If you can log in at geckoboard, you'll find your api key in your account details.</param>
        /// <param name="client">If you provide your own HttpClient here, you are responsible for cleaning up afterwards. Otherwise, you can safely assume that any internally created HttpClients will be Disposed when you Dispose this Geckoboard.</param>
        public Geckoboard(string apiKey, HttpClient client = null)
        {
            _api = Create(new GeckoApiSettings(apiKey), client);
        }

        /// <summary>
        /// Retrieves a proxy to an already existing widget in the current geckoboard. You can use this proxy to Push new data to the widget.
        /// </summary>
        /// <param name="widgetKey">The widget key can be found in the edit view of your widget at geckoboard.com. It usually looks something like 168149-9e42d098-8f93-4c3f-ad7e-e4480e333b09</param>
        /// <returns></returns>
        public IWidget<object> GetWidget(string widgetKey)
        {
            return GetWidget<DefaultWidgetDataFactory, object>(widgetKey, new DefaultWidgetDataFactory());
        }

        /// <summary>
        /// Just as the overloaded method, this method retrieves a proxy to an already existing widget in the current geckoboard. 
        /// However, this overload can be used when you have created som specific WidgetDataFactory to be responsible for formatting
        /// the data sent to the widget.
        /// </summary>
        /// <typeparam name="TFactory">The type of the WidgetDataFactory which must implement IWidgetDataFactory Of TInput</typeparam>
        /// <typeparam name="TInput">The type of the input your TFactory takes.</typeparam>
        /// <param name="widgetKey">The widget key can be found in the edit view of your widget at geckoboard.com. It usually looks something like 168149-9e42d098-8f93-4c3f-ad7e-e4480e333b09</param>
        /// <param name="widgetDataFactory">An instance of TFactory</param>
        /// <returns></returns>
        public IWidget<TInput> GetWidget<TFactory, TInput>(string widgetKey, TFactory widgetDataFactory) where TFactory : IWidgetDataFactory<TInput>
        {
            return new Widget<TFactory, TInput>(widgetKey, _api, widgetDataFactory);
        }

        /// <summary>
        /// Special case for when your TFactory has an empty constructor
        /// </summary>
        /// <typeparam name="TFactory">The type of the WidgetDataFactory which must implement IWidgetDataFactory Of TInput and also have an empty constructor</typeparam>
        /// <typeparam name="TInput">The type of the input your TFactory takes</typeparam>
        /// <param name="widgetKey">The widget key can be found in the edit view of your widget at geckoboard.com. It usually looks something like 168149-9e42d098-8f93-4c3f-ad7e-e4480e333b09</param>
        /// <returns></returns>
        public IWidget<TInput> GetWidget<TFactory, TInput>(string widgetKey) where TFactory : IWidgetDataFactory<TInput>, new()
        {
            return new Widget<TFactory, TInput>(widgetKey, _api, new TFactory());
        }

        private IGeckoApi Create(GeckoApiSettings settings, HttpClient client = null)
        {
            const string Host = "https://push.geckoboard.com";
            return client == null ? Api.For<IGeckoApi>(Host, settings) : Api.For<IGeckoApi>(client, settings);
        }

        /// <summary>
        /// Disposes the api which will dispose any internally created HttpClients.
        /// </summary>
        public void Dispose()
        {
            _api.Dispose();
        }
    }
}