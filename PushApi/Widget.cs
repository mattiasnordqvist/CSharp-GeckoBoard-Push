using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using CSharpGeckoBoardPush.Factory;

namespace CSharpGeckoBoardPush
{
    /// <summary>
    /// A proxy to an already existing widget in your geckoboard. You can use this proxy to Push new data to the widget.
    /// </summary>
    /// <typeparam name="TFactory">The type responsible for creating data understood by Geckoboard from a TInput</typeparam>
    /// <typeparam name="TInput">The type of the input your TFactory takes.</typeparam>
    public class Widget<TFactory, TInput> where TFactory : IWidgetDataFactory<TInput>
    {
        private readonly IGeckoApi _api;

        private readonly TFactory _widgetDataFactory;

        private readonly string _widgetKey;

        internal Widget(string widgetKey, IGeckoApi api, TFactory widgetDataFactory)
        {
            _api = api;
            _widgetDataFactory = widgetDataFactory;
            WidgetKeyGuard(widgetKey);
            _widgetKey = widgetKey;
        }

        /// <summary>
        /// Updates your geckoboard widget with new data.
        /// </summary>
        /// <param name="data">The data to push to Geckoboard. This data will be mangled by any TFactory or the default DefaultWidgetDataFactory</param>
        /// <returns>A HttpResponse from Geckoboard</returns>
        public async Task<HttpResponseMessage> Push(TInput data)
        {
            return await _api.Push(new WidgetData(_widgetKey, _widgetDataFactory.CreateData(data)));
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
            NullGuard(widgetKey, nameof(widgetKey));

            const string Regex = "^[0-9a-f]{5,6}-[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$";

            if (!new Regex(Regex).IsMatch(widgetKey))
            {
                throw new ArgumentException($"{nameof(widgetKey)} has wrong format", nameof(widgetKey));
            }
        }
    }
}