using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeCopUI_Framework.Child
{
    public class HItemCollection : Collection<object>
    {
        /// <summary>
        /// An event for to determine whether and item or items added or removed.
        /// </summary>
        public event EventHandler ItemUpdated;
        public delegate void EventHandler(object sender, EventArgs e);
        public HItemCollection()
        {

        }

        public HItemCollection(object item)
        {

        }

        /// <summary>
        /// Adds an array of items to the list of items for a MetroSetListBox.
        /// </summary>
        /// <param name="items">An IEnumerable of objects to add to the list.</param>
        public void AddRange(IEnumerable<object> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Adds an item to the list of items for a MetroSetListBox.
        /// </summary>
        /// <param name="item">An object representing the item to add to the collection.</param>
        protected new void Add(object item)
        {
            base.Add(item);
            ItemUpdated?.Invoke(this, null);
        }

        /// <summary>
        /// Inserts an item into the list box at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index location where the item is inserted.</param>
        /// <param name="item">An object representing the item to insert.</param>
        protected override void InsertItem(int index, object item)
        {
            base.InsertItem(index, item);
            ItemUpdated?.Invoke(this, null);
        }

        /// <summary>
        /// Removes the specified object from the collection.
        /// </summary>
        /// <param name="value">An object representing the item to remove from the collection.</param>
        protected override void RemoveItem(int value)
        {
            base.RemoveItem(value);
            ItemUpdated?.Invoke(this, null);
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        protected new void Clear()
        {
            base.Clear();
            ItemUpdated?.Invoke(this, null);
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        protected override void ClearItems()
        {
            base.ClearItems();
            ItemUpdated?.Invoke(this, null);
        }
    }
}
