using System;
using System.Collections;
using System.Collections.Generic;

namespace HeCopUI_Framework.Controls.TreeView
{
    public class TreeNodeCollection : IList<TreeNode>, ICollection<TreeNode>, IEnumerable<TreeNode>, IList, ICollection, IReadOnlyList<TreeNode>, IReadOnlyCollection<TreeNode>, IEnumerable
    {
        private HTreeView owner;
        private TreeNode parentNode;
        private List<TreeNode> m_arrItem;
        private readonly object syncRoot = new object(); // Khởi tạo syncRoot một lần

        public TreeNodeCollection(HTreeView owner) : this()
        {
            this.owner = owner;
        }

        public TreeNodeCollection(TreeNode parentNode) : this()
        {
            this.parentNode = parentNode;
            owner = parentNode?.Owner;
        }

        public TreeNodeCollection()
        {
            m_arrItem = new List<TreeNode>();
        }

        public TreeNode this[int index] { get => m_arrItem[index]; set => m_arrItem[index] = value; }
        object IList.this[int index] { get => m_arrItem[index]; set => m_arrItem[index] = value as TreeNode; }

        public int Count => m_arrItem.Count;

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public object SyncRoot => syncRoot; // Trả về syncRoot đã khởi tạo

        public bool IsSynchronized => false;

        public void Add(TreeNode item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            item.Parent = parentNode; // Thiết lập parent cho node
            item.Owner = owner;

            item.Index = m_arrItem.Count; // Cập nhật chỉ số

            if (string.IsNullOrEmpty(item.Text))
                item.Text = $"tree Node {item.Index}";

            if (string.IsNullOrEmpty(item.Name))
                item.Name = $"treeNode{item.Index}";

            m_arrItem.Add(item);
            owner?.Invalidate();
        }

        public int Add(object value)
        {
            if (value is TreeNode node)
            {
                node.Parent = parentNode;
                node.Owner = owner;
                Add(node);
                return m_arrItem.Count - 1;
            }
            throw new ArgumentException("Value must be of type TreeNode.");
        }

        public void AddRange(IEnumerable<TreeNode> nodes)
        {
            if (nodes == null)
                throw new ArgumentNullException(nameof(nodes));

            foreach (var item in nodes)
            {
                if (item == null)
                    throw new ArgumentNullException(nameof(item));
                item.Parent = parentNode;
                item.Owner = owner;
            }
            m_arrItem.AddRange(nodes);
            owner?.Invalidate();
        }

        public void Clear()
        {
            foreach (var node in m_arrItem)
            {
                node.Parent = null; // Xóa parent khi xóa node
            }
            m_arrItem.Clear();
            owner?.Invalidate();
        }

        public bool Contains(TreeNode item)
        {
            return m_arrItem.Contains(item);
        }

        public bool Contains(object value)
        {
            return m_arrItem.Contains(value as TreeNode);
        }

        public void CopyTo(TreeNode[] array, int arrayIndex)
        {
            foreach (var item in array)
            {
                item.Owner = owner;
            }
            m_arrItem.CopyTo(array, arrayIndex);
        }

        public void CopyTo(Array array, int index)
        {
            if (array is TreeNode[] treeNodeArray)
            {
                CopyTo(treeNodeArray, index);
            }
            else
            {
                throw new ArgumentException("Array is not of type TreeNode[].");
            }
        }

        public IEnumerator<TreeNode> GetEnumerator()
        {
            return m_arrItem.GetEnumerator();
        }

        public int IndexOf(TreeNode item)
        {
            return m_arrItem.IndexOf(item);
        }

        public int IndexOf(object value)
        {
            return m_arrItem.IndexOf(value as TreeNode);
        }

        public void Insert(int index, TreeNode item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (item.Parent != null)
                throw new InvalidOperationException("Node already has a parent.");

            item.Owner = owner;

            item.Parent = parentNode; // Thiết lập parent cho node
            item.Index = index; // Cập nhật chỉ số

            m_arrItem.Insert(index, item);
            owner?.Invalidate();
        }

        public void Insert(int index, object value)
        {
            if (value is TreeNode node)
            {
                Insert(index, node);
            }
            else
            {
                throw new ArgumentException("Value must be of type TreeNode.");
            }
        }

        public bool Remove(TreeNode item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            bool result = m_arrItem.Remove(item);
            if (result)
            {
                item.Parent = null; // Xóa parent khi xóa node
                owner?.Invalidate();
            }
            return result;
        }

        public void Remove(object value)
        {
            if (value is TreeNode node)
            {
                Remove(node);
            }
            else
            {
                throw new ArgumentException("Value must be of type TreeNode.");
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= m_arrItem.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var node = m_arrItem[index];
            m_arrItem.RemoveAt(index);
            node.Parent = null; // Xóa parent khi xóa node
            owner?.Invalidate();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_arrItem.GetEnumerator();
        }
    }
}
