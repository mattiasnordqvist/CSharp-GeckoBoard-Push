using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGeckoBoardPush.Widgets.Text
{
    public class Text : Widget
    {
        public Text(string widgetKey)
            : base(widgetKey)
        {
            Data = new Data();
        }

        public Data Data { get; set; }
    }

}
