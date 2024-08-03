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
    public class TableRow
    {
        public TableRow Parent;
        public bool IsSubRow => Parent != null;
        public string Text { get; set; }
        public string Name { get; set; }
   
        public int Width { get; set; } = 100;
        public int Index { get; set; } = -1;

        public Rectangle Bounds = Rectangle.Empty;

        public Image Image { get; set; }

        public CheckState CheckState { get; set; } = CheckState.Unchecked;

        public bool IsSelected { get; set; } = false;

        //TableRowCollection subRows = new TableRowCollection();

        //[Localizable(true)]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TableRowCollection SubRows { get; set; } = new TableRowCollection();


        public TableRow this[int index] => SubRows[index];

        public TableRow()
        {
            SubRows = new TableRowCollection(this);
        }

        public TableRow(string text):this()
        {
            Text=text;
        }

        public TableRow(string text, TableRow[] tableRows)
        {
            Text=text;
            SubRows.AddRange(tableRows);
        }
    }


}
