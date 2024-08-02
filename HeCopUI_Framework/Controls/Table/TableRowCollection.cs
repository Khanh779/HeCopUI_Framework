using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility_Tools.CustomControl.Table
{
    public class TableRowCollection : IList, ICollection, IEnumerable
    {
        private List<TableRow> rows = new List<TableRow>();

        TableRow parent;


        public TableRowCollection(TableRow parent) : this()
        {
            this.parent = parent;
        }

        public TableRowCollection()
        {
            rows = new List<TableRow>();
        }


        public TableRow this[int index]
        {
            get => rows[index];
            set => rows[index] = value;
        }

        object IList.this[int index]
        {
            get => this[index];
            set => this[index] = (TableRow)value;
        }



        public int Count => rows.Count;

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        public void Add(TableRow item)
        {
            if (parent != null)
            {
                item.Parent = parent;
            }

            // Tự động gán các thuộc tính lần đầu tiên thêm vào
            int index = rows.Count;

            // Gán giá trị Index và DisplayIndex
            item.Index = index;

            // Gán giá trị Name và Text nếu chưa được chỉ định
            if (string.IsNullOrEmpty(item.Name))
            {
                item.Name = item.Parent==null ? "row" : "subRow" + index;
            }

            if (string.IsNullOrEmpty(item.Text))
                item.Text = item.Parent== null ? "row" : "subRow" + index;

            rows.Add(item);
        }

        public void AddRange(TableRow[] items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public TableRow[] ToArray()
        {
            return rows.ToArray();
        }

        public void AddObjects(params object[] items)
        {
            TableRow tableRow = new TableRow();
            for (int i = 0; i < items.Length; i++)
            {
                if (i == 0)
                {
                    if (tableRow.Index == -1)
                        tableRow.Index = rows.Count;
                    tableRow.Text = items[i].ToString();
                }
                else
                {
                    var sub = new TableRow();
                    sub.Text = items[i].ToString();
                    if (sub.Index == -1)
                        sub.Index = tableRow.SubRows.Count;


                    tableRow.SubRows.Add(sub);
                }
            }
            Add(tableRow);
        }

        int IList.Add(object value)
        {
            if (value is TableRow row)
            {
                Add(row);
                return rows.Count - 1;
            }
            throw new ArgumentException("The value provided is not of type TableRow.", nameof(value));
        }

        public void Clear()
        {
            rows.Clear();
        }

        public bool Contains(TableRow item)
        {
            return rows.Contains(item);
        }

        public bool Contains(object value)
        {
            if (value is TableRow row)
            {
                return Contains(row);
            }
            return false;
        }

        public void CopyTo(TableRow[] array, int arrayIndex)
        {
            rows.CopyTo(array, arrayIndex);
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (index < 0 || index >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

            if (array.Rank != 1)
                throw new ArgumentException("Array must be one-dimensional.", nameof(array));

            if (array.Length - index < Count)
                throw new ArgumentException("Array is too small to copy all the elements.");

            foreach (var item in rows)
            {
                array.SetValue(item, index);
                index++;
            }
        }

        public IEnumerator<TableRow> GetEnumerator()
        {
            return rows.GetEnumerator();
        }

        public int IndexOf(object value)
        {
            if (value is TableRow row)
            {
                return rows.IndexOf(row);
            }
            return -1;
        }

        public void Insert(int index, object value)
        {
            if (value is TableRow row)
            {
                rows.Insert(index, row);

                // Cập nhật các thuộc tính Index và DisplayIndex
                row.Index = index;

                // Cập nhật lại chỉ số cho các hàng sau
                for (int i = index + 1; i < rows.Count; i++)
                {
                    rows[i].Index = i;
                }
            }
            else
            {
                throw new ArgumentException("The value provided is not of type TableRow.", nameof(value));
            }
        }

        public void Remove(object value)
        {
            if (value is TableRow row)
            {
                rows.Remove(row);

                // Cập nhật lại chỉ số cho các hàng sau khi xóa
                for (int i = 0; i < rows.Count; i++)
                {
                    rows[i].Index = i;
                }
            }
            else
            {
                throw new ArgumentException("The value provided is not of type TableRow.", nameof(value));
            }
        }

        public void RemoveAt(int index)
        {
            rows.RemoveAt(index);



        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return rows.GetEnumerator();
        }
    }

}
