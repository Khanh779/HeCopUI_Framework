using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace HeCopUI_Framework.Controls.Chart.Model
{
    public class DataItems
    {
        public DataItems()
        {
            Items = new List<Items>();

        }

        public List<Items> Items = new List<Items>();

        public bool IsItemExists(List<Items> items, string key)
        {
            return items.Any(existingItem =>
                existingItem.Data.Keys.Contains(key));
        }

        public void Add(string legendText, Dictionary<object, float> items, Color color)
        {
            Items itema = new Items() { LegendText = legendText, Data = items, Color = color };
            Items.Add(itema);

        }

    }

    public class Items
    {
        public string LegendText { get; set; }
        public Dictionary<object, float> Data { get; set; }
        public Color Color { get; set; }

    }

}
