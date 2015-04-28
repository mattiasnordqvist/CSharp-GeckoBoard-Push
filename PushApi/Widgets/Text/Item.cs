namespace CSharpGeckoBoardPush.Widgets.Text
{
    public class Item
    {
        public Item(string text)
        {
            this.Text = text;
        }

        public string Text { get; set; }
        public int Type { get; set; }
    }
}