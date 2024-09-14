#region Imports

using HeCopUI_Framework.Child;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace HeCopUI_Framework.Controls
{

    #region MaterialListBox

    [DefaultProperty("Items")]
    [DefaultEvent("SelectedIndexChanged")]
    [ComVisible(true)]
    public class HListBox : Control
    {
        #region Internal Vars

        private HItemCollection _items = new HItemCollection();
        private List<object> _selectedItems;
        private List<object> _indicates;
        private bool _multiSelect;
        private int _selectedIndex;
        private HItemCollection _selectedItem;
        private string _selectedText;
        private bool _showScrollBar;
        private bool _multiKeyDown;
        private int _hoveredItem;
        private HScrollBar _scrollBar;
        private object _selectedValue;

        private bool _updating = false;
        private int _itemHeight = 30;

        private Color _borderColor = Global.PrimaryColors.BorderNormalColor1;



        #endregion Internal Vars


        #region Properties




        [TypeConverter(typeof(CollectionConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public HItemCollection Items => _items;

        [Browsable(false)]
        public List<object> SelectedItems => _selectedItems;

        public HItemCollection SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                _selectedIndex = _items.IndexOf(_selectedItem);
                update_selection();
                Invalidate();
            }
        }

        public string SelectedText
        {
            get => _selectedText;
            //set
            //{
            //    _selectedText = value;
            //    Invalidate();
            //}
        }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                update_selection();
                Invalidate();
            }
        }

        public object SelectedValue
        {
            get => _selectedValue;
            //set
            //{
            //    _selectedValue = value;
            //    Invalidate();
            //}
        }

        public bool MultiSelect
        {
            get => _multiSelect;
            set
            {
                _multiSelect = value;

                if (_selectedItems.Count > 1)
                {
                    _selectedItems.RemoveRange(1, _selectedItems.Count - 1);
                }

                Invalidate();
            }
        }

        [Browsable(false)]
        public int Count => _items.Count;

        public bool ShowScrollBar
        {
            get => _showScrollBar;
            set
            {
                _showScrollBar = value;
                _scrollBar.Visible = value;
                Invalidate();
            }
        }






        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text { get => base.Text; set => base.Text = value; }


        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Refresh();
            }
        }




        #endregion Properties

        #region Constructors

        public HListBox()
        {
            SetStyle
            (
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.Selectable |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                    true
            );
            UpdateStyles();

            SetDefaults();


            MultiSelect = false;



        }

        private Color thumbBarColor = Color.LightGray;
        public Color ThumbBarColor
        {
            get { return thumbBarColor; }
            set
            {
                thumbBarColor = value; Invalidate();
            }
        }

        private Color thumbColor = Global.PrimaryColors.BackHoverColor1;
        public Color ThumbColor
        {
            get { return thumbColor; }
            set
            {
                thumbColor = value; Invalidate();
            }
        }

        private Color thumbHoverColor = Color.FromArgb(10, 198, 172);
        public Color ThumbHoverColor
        {
            get { return thumbHoverColor; }
            set
            {
                thumbHoverColor = value; Invalidate();
            }
        }

        private void SetDefaults()
        {
            SelectedIndex = -1;
            _hoveredItem = -1;
            _showScrollBar = false;
            _items.ItemUpdated += InvalidateScroll;
            _selectedItems = new List<object>();
            _indicates = new List<object>();
            _multiKeyDown = false;
            _scrollBar = new HScrollBar()
            {
                Orientation = ScrollOrientation.VerticalScroll,
                Size = new Size(12, Height),
                Maximum = _items.Count * _itemHeight,
                SmallChange = _itemHeight,
                LargeChange = _itemHeight,
                ThumbColor = thumbColor,
                HoverThumbColor = thumbHoverColor,
                BarColor = thumbBarColor

            };
            _scrollBar.Scroll += HandleScroll;
            _scrollBar.MouseDown += VS_MouseDown;
            _scrollBar.BackColor = Color.Transparent;
            if (!Controls.Contains(_scrollBar))
            {
                Controls.Add(_scrollBar);
            }


        }

        #endregion Constructors


        private Color listBoxColor = Color.White;
        private Color dlistBoxColor = Color.LightGray;
        private Color selectedItemColor = Global.PrimaryColors.BackNormalColor1;
        private Color hoveredItemColor = Global.PrimaryColors.BackHoverColor1;
        private Color itemNormalColor = Global.PrimaryColors.BackNormalColor1;
        private Color textColor = Color.FromArgb(64, 64, 64);
        private Color hoverText = Color.WhiteSmoke;
        private Color downText = Color.White;

        public Color TextSelectedColor
        {
            get { return downText; }
            set
            {
                downText = value; Invalidate();
            }
        }

        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value; Invalidate();
            }
        }

        public Color TextHoverColor
        {
            get { return hoverText; }
            set
            {
                hoverText = value; Invalidate();
            }
        }

        public Color ItemColor
        {
            get { return itemNormalColor; }
            set
            {
                itemNormalColor = value; Invalidate();
            }
        }

        public Color HoveredItemColor
        {
            get { return hoveredItemColor; }
            set
            {
                hoveredItemColor = value; Invalidate();
            }
        }

        public Color ListBoxColor
        {
            get { return listBoxColor; }
            set
            {
                listBoxColor = value; Invalidate();
            }
        }

        public Color DisableListBoxColor
        {
            get { return dlistBoxColor; }
            set
            {
                dlistBoxColor = value; Invalidate();
            }
        }

        public Color SelectedItemColor
        {
            get { return selectedItemColor; }
            set
            {
                selectedItemColor = value; Invalidate();
            }
        }

        #region Draw Control

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_updating == true) return;

            Graphics g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            //g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            Rectangle mainRect = new Rectangle(0, 0, Width - ((BorderThickness > 0) ? BorderThickness : 0), Height - ((BorderThickness > 0) ? BorderThickness : 0));
            if (Items.Count > 0)
            {

                int lastItem = (_scrollBar.Value / _itemHeight) + (Height / _itemHeight) + 1 > Items.Count ? Items.Count : (_scrollBar.Value / _itemHeight) + (Height / _itemHeight) + 1;
                int firstItem = _scrollBar.Value / _itemHeight < 0 ? 0 : (_scrollBar.Value / _itemHeight);

                g.FillRectangle(new SolidBrush(Enabled ? listBoxColor : dlistBoxColor), mainRect);



                //Set color and brush
                Color SelectedColor = selectedItemColor;

                SolidBrush SelectedBrush = new SolidBrush(SelectedColor);

                //Draw items
                for (int i = firstItem; i < lastItem; i++)
                {
                    string itemText = Items[i].ToString();


                    Rectangle itemRect = new Rectangle(0, (i - firstItem) * _itemHeight, Width - BorderThickness - (_showScrollBar && _scrollBar.Visible ? _scrollBar.Width : 0), _itemHeight);

                    if (MultiSelect && _indicates.Count != 0)
                    {
                        if (i == _hoveredItem && !_indicates.Contains(i))
                        {
                            g.FillRectangle(new SolidBrush(hoveredItemColor), itemRect);

                        }
                        else if (_indicates.Contains(i))
                        {
                            g.FillRectangle(Enabled ?
                                SelectedBrush :
                                new SolidBrush(itemNormalColor),
                                itemRect);

                        }
                    }
                    else
                    {
                        if (i == _hoveredItem && i != SelectedIndex)
                        {
                            g.FillRectangle(new SolidBrush(hoveredItemColor), itemRect);

                        }
                        else if (i == SelectedIndex)
                        {
                            g.FillRectangle(Enabled ?
                                SelectedBrush :
                                new SolidBrush(itemNormalColor),
                                itemRect);

                        }
                    }
                    g.DrawString(itemText, Font, new SolidBrush((i == SelectedIndex) ? downText : (i == _hoveredItem) ? hoverText : textColor),
                       itemRect.X + 4, itemRect.Top + itemRect.Height / 2 - g.MeasureString(itemText, Font).Height / 2);


                }

            }

            if ((BorderThickness > 0))
            {
                g.DrawRectangle(new Pen(new SolidBrush(BorderColor), bt) { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset }, new
                    Rectangle(0, 0, Width - 1, Height - 1));
            }
        }


        int bt = 1;
        public int BorderThickness
        {
            get { return bt; }
            set
            {
                bt = value; Invalidate();
            }
        }

        #endregion Draw Control

        #region Methods

        public void AddItem(HItemCollection newItem)
        {
            _items.Add(newItem);
            InvalidateScroll(this, null);
            ItemsCountChanged?.Invoke(this, new EventArgs());
        }

        public void AddItem(string newItem)
        {
            //HItemCollection _newitemMLBI = new HItemCollection(newItem);
            _items.Add(newItem);
            InvalidateScroll(this, null);
            ItemsCountChanged?.Invoke(this, new EventArgs());
        }

        public void AddItems(HItemCollection[] newItems)
        {
            _updating = true;
            foreach (HItemCollection str in newItems)
            {
                AddItem(str);
            }
            _updating = false;

            InvalidateScroll(this, null);
            ItemsCountChanged?.Invoke(this, new EventArgs());
        }

        public void AddItems(string[] newItems)
        {
            _updating = true;
            foreach (string str in newItems)
            {
                AddItem(str);
            }
            _updating = false;

            InvalidateScroll(this, null);
            ItemsCountChanged?.Invoke(this, new EventArgs());
        }

        public void RemoveItemAt(int index)
        {
            if (index <= _selectedIndex)
            {
                _selectedIndex -= 1;
                update_selection();
            }
            _items.RemoveAt(index);
            InvalidateScroll(this, null);
            ItemsCountChanged?.Invoke(this, new EventArgs());
        }

        public void RemoveItem(HItemCollection item)
        {
            if (_items.IndexOf(item) <= _selectedIndex)
            {
                _selectedIndex -= 1;
                update_selection();
            }
            _items.Remove(item);
            InvalidateScroll(this, null);
            ItemsCountChanged?.Invoke(this, new EventArgs());
        }

        public int IndexOf(HItemCollection value)
        {
            return _items.IndexOf(value);
        }

        public void RemoveItems(HItemCollection[] itemsToRemove)
        {
            _updating = true;
            foreach (HItemCollection item in itemsToRemove)
            {
                if (_items.IndexOf(item) <= _selectedIndex)
                {
                    _selectedIndex -= 1;
                    update_selection();
                }
                _items.Remove(item);
            }
            _updating = false;

            InvalidateScroll(this, null);
            ItemsCountChanged?.Invoke(this, new EventArgs());
        }

        private void update_selection()
        {
            if (_selectedIndex >= 0)
            {
                _selectedItem = _items;
                _selectedValue = _items[_selectedIndex];
                _selectedText = _items[_selectedIndex].ToString();
            }
            else
            {
                _selectedItem = null;
                _selectedValue = null;
                _selectedText = null;
            }
        }

        public void Clear()
        {
            _updating = true;
            for (int i = _items.Count - 1; i >= 0; i += -1)
            {
                _items.RemoveAt(i);
            }
            _updating = false;
            _selectedIndex = -1;
            update_selection();

            InvalidateScroll(this, null);
            ItemsCountChanged?.Invoke(this, new EventArgs());
        }

        public void BeginUpdate()
        {
            _updating = true;
        }

        public void EndUpdate()
        {
            _updating = false;
        }

        #endregion Methods

        #region Events

        [Category("Behavior")]
        [Description("Occurs when selected index change.")]
        public event SelectedIndexChangedEventHandler SelectedIndexChanged;

        public delegate void SelectedIndexChangedEventHandler(object sender, HItemCollection selectedItem);

        [Category("Behavior")]
        [Description("Occurs when selected value change.")]
        public event SelectedValueEventHandler SelectedValueChanged;

        public delegate void SelectedValueEventHandler(object sender, HItemCollection selectedItem);

        [Category("Behavior")]
        [Description("Occurs when item is added or removed.")]
        public event EventHandler ItemsCountChanged;

        #endregion Events

        protected override void OnSizeChanged(EventArgs e)
        {
            InvalidateScroll(this, e);
            InvalidateLayout();
            base.OnSizeChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            if (e.Button == MouseButtons.Left)
            {
                int index = _scrollBar.Value / _itemHeight + e.Location.Y / _itemHeight;
                if (index >= 0 && index < _items.Count)
                {
                    if (MultiSelect && _multiKeyDown)
                    {
                        _indicates.Add(index);
                        _selectedItems.Add(Items[index]);
                    }
                    else
                    {
                        _indicates.Clear();
                        _selectedItems.Clear();
                        _selectedItem = Items;
                        _selectedIndex = index;
                        _selectedValue = Items[index];
                        _selectedText = Items[index].ToString();
                        SelectedIndexChanged?.Invoke(this, _selectedItem);
                        SelectedValueChanged?.Invoke(this, _selectedItem);
                    }
                }
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        private void HandleScroll(object sender, ScrollEventArgs e)
        {
            if (_scrollBar.Maximum < _scrollBar.Value + Height) _scrollBar.Value = _scrollBar.Maximum - Height;
            Invalidate();
        }

        private void InvalidateScroll(object sender, EventArgs e)
        {
            _scrollBar.Maximum = _items.Count * _itemHeight;
            _scrollBar.SmallChange = _itemHeight;
            _scrollBar.LargeChange = Height;
            _scrollBar.Visible = (_items.Count * _itemHeight) > Height;
            if (_items.Count == 0)
            { _scrollBar.Value = 0; }
            if (_items.Count > 0)
                if (ShowScrollBar == true) _scrollBar.Visible = true;
            Invalidate();
        }

        private void VS_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
        }

        private void InvalidateLayout()
        {
            _scrollBar.Size = new Size(12, Height - ((BorderThickness > 0) ? BorderThickness - 3 : 0));
            _scrollBar.Location = new Point(Width - (_scrollBar.Width + ((BorderThickness > 0) ? BorderThickness : 0)), (BorderThickness > 0) ? BorderThickness : 0);
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (_scrollBar.Visible == true)
            {
                if (_scrollBar.Minimum > _scrollBar.Value - e.Delta / 2)
                    _scrollBar.Value = _scrollBar.Minimum;
                else if (_scrollBar.Maximum < _scrollBar.Value + Height)
                {
                    if (e.Delta > 0)
                        _scrollBar.Value -= e.Delta / 2;
                    else
                    { } //Do nothing, maximum reached
                }
                else
                    _scrollBar.Value -= e.Delta / 2;

                _updateHoveredItem(e);

                Invalidate();
                base.OnMouseWheel(e);
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Down:
                    try
                    {
                        _selectedItems.Remove(_items[SelectedIndex]);
                        SelectedIndex += 1;
                        _selectedItems.Add(_items[SelectedIndex]);
                    }
                    catch
                    {
                        //
                    }
                    break;

                case Keys.Up:
                    try
                    {
                        _selectedItems.Remove(_items[SelectedIndex]);
                        SelectedIndex -= 1;
                        _selectedItems.Add(_items[SelectedIndex]);
                    }
                    catch
                    {
                        //
                    }
                    break;
            }
            Invalidate();
            return base.IsInputKey(keyData);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Cursor = Cursors.Hand;
            _updateHoveredItem(e);

            Invalidate();
        }

        private void _updateHoveredItem(MouseEventArgs e)
        {
            int index = _scrollBar.Value / _itemHeight + e.Location.Y / _itemHeight;

            if (index >= Items.Count)
            {
                index = -1;
            }

            if (index >= 0 && index < Items.Count)
            {
                _hoveredItem = index;
            }

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _hoveredItem = -1;
            Cursor = Cursors.Default;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scrollBar.Size = new Size(12, Height - ((BorderThickness > 0) ? BorderThickness - 3 : 0));
            _scrollBar.Location = new Point(Width - (_scrollBar.Width + ((BorderThickness > 0) ? BorderThickness : 0)), (BorderThickness > 0) ? BorderThickness : 0);
            InvalidateScroll(this, e);
        }

        public const int WM_SETCURSOR = 0x0020;
        public const int IDC_HAND = 32649;

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetCursor(IntPtr hCursor);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETCURSOR)
            {
                SetCursor(LoadCursor(IntPtr.Zero, IDC_HAND));
                m.Result = IntPtr.Zero;
                return;
            }
            base.WndProc(ref m);
        }
    }

    #endregion

}
