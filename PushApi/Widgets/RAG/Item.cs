namespace CSharpGeckoBoardPush.Widgets.RAG
{
    public class Item
    {
        public Item(string text)
        {
            Text = text;
            Prefix = "%";
        }

        public string Text { get; set; }
        public int? Value { get; set; }
        public string Prefix { get; set; }
    }
}