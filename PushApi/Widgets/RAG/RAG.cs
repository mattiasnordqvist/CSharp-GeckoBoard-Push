using System.Collections.Generic;

namespace CSharpGeckoBoardPush.Widgets.RAG
{
    /// <summary>
    /// https://developer.geckoboard.com/#rag
    /// </summary>
    public class RAG : Widget
    {
        public RAG(string widgetKey, RagItem red, RagItem amber, RagItem green = null)
            : base(widgetKey)
        {
            NullGuard(red, "red");
            NullGuard(amber, "amber");
            Red = red;
            Amber = amber;
            Green = green;
        }

        public bool Reverse { get; set; }

        public RagItem Red { get; private set; }

        public RagItem Amber { get; private set; }

        public RagItem Green { get; set; }

        public override object CreateData()
        {
            var data = new Data { Type = Reverse ? "reverse" : string.Empty, Item = new List<RagItem>() };
            data.Item.Add(Red);
            data.Item.Add(Amber);

            if (Green != null)
            {
                data.Item.Add(Green);
            }

            return data;
        }
    }
}
