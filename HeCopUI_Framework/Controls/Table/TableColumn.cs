using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility_Tools.CustomControl.Table
{
    public class TableColumn
    {
        public int Index { get; set; } = -1;
        public int DisplayIndex { get; set; } = -1;
        public string Text { get; set; }
        public string Name { get; set; }

        [Bindable(false), Browsable(false)]
        public RectangleF Bounds { get; internal set; }

        [Bindable(false), Browsable(false)]
        public SimpleTable Owner { get; internal set; }

        public int Width { get; set; } = 100;

        public TableColumn()
        {

        }

        public TableColumn(string text) : this()
        {
            Text = text;
        }


        public override string ToString()
        {

            return Name;
        }
    }

}
