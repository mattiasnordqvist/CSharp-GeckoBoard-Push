namespace CSharpGeckoBoardPush.Widgets.RAG
{
    public class RagItem
    {
        public RagItem(string text)
        {
            Text = text;
        }

        public RagItem(string text, int? value) : this(text)
        {
            Value = value;
        }

        public RagItem(string text, int? value, string prefix)
            : this(text, value)
        {
            Prefix = prefix;
        }

        public string Text { get; set; }
        public int? Value { get; set; }
        public string Prefix { get; set; }
    }
}