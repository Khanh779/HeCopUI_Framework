using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace HeCopUI_Framework.Controls.Chart.Model
{
    public class DataItems
    {
        // Tôi muốn bạn tạo các thuộc tính cho các loại biểu đồ khác nhau ở đây
        public DataItems()
        {
            Items = new List<Items>();
         
        }

        public bool isExists(object key, int index)
        {
            bool isExists = false;
            foreach (var kvp in Items[index].Data)
            {
                if (kvp.Key == key)
                {
                    isExists = true;
                    break;
                }

            }
            return isExists;
        }

        public List<Items> Items = new List<Items>();

        public bool IsItemExists(List<Items> items, string key)
        {
            // Kiểm tra xem có Items nào có chứa key giống nhau hay không
            return items.Any(existingItem =>
                existingItem.Data.Keys.Contains(key));
        }

        // Tạo một hàm thêm dữ liệu cho biểu đồ có Dictionary, List<int, double> và Color
        public void Add(string legendText, Dictionary<object, int> items, Color color)
        {
            Items itema = new Items() { LegendText = legendText, Data = items, Color = color };
            Items.Add(itema);

        }

    }

    public class Items
    {
        public string LegendText { get; set; }
        public Dictionary<object, int> Data { get; set; }
        public Color Color { get; set; }

    }
    
}
