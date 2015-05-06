namespace CSharpGeckoBoardPush.Widgets.RAG
{
    public class RAG : Widget
    {
        public RAG(string widgetKey)
            : base(widgetKey)
        {
            Data = new Data();
        }
        public Data Data { get; set; }
    }
}
