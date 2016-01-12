namespace CSharpGeckoBoardPush
{
    /// <summary>
    /// Responsible for creating data that can understood by Geckoboard given a TInput as input
    /// </summary>
    /// <typeparam name="TInput">A type that contains all information you need to create proper Geckoboard widget input</typeparam>
    public interface IWidgetDataFactory<in TInput>
    {
        /// <summary>
        /// This method takes some data and returns some valid Geckoboard widget input.
        /// </summary>
        /// <param name="input">The data you wish to transform to some kind Geckoboard widget input</param>
        /// <returns>Should return some object that, when serialized to json, looks like something found in this documentation: https://developer.geckoboard.com/#custom-widget-types</returns>
        object CreateData(TInput input);
    }
}