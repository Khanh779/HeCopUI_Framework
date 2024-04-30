using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;

namespace HeCopUI_Framework.Controls
{

    public partial class HListView : ListView
    {
        [Browsable(false)]
        public int Depth { get; set; }



        private MouseState HMouseState { get; set; }

        public enum MouseState { OUT, HOVER, DOWN }

        [Browsable(false)]
        public Point MouseLocation { get; set; }

        private bool _autoSizeTable;

        [Category("Appearance"), Browsable(true)]
        public bool AutoSizeTable
        {
            get
            {
                return _autoSizeTable;
            }
            set
            {
                _autoSizeTable = value;
                Scrollable = !value;
            }
        }

        [Browsable(false)]
        private ListViewItem HoveredItem { get; set; }

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool OwnerDraw
        //{
        //    get { return base.OwnerDraw; }
        //    set
        //    {
        //        base.OwnerDraw = true;
        //    }
        //}

        public HListView()
        {

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw, true);
            //FullRowSelect = true;

            View = View.Details;
            base.OwnerDraw = true;
            //HideSelection = true;
            ResizeRedraw = true;
            BorderStyle = BorderStyle.None;


            // Fix for hovers, by default it doesn't redraw
            MouseLocation = new Point(-1, -1);
            HMouseState = MouseState.OUT;
            MouseEnter += delegate
            {
                HMouseState = MouseState.HOVER; Invalidate();
            };
            MouseLeave += delegate
            {
                HMouseState = MouseState.OUT;
                MouseLocation = new Point(-1, -1);
                HoveredItem = null;
                Invalidate();
            };
            MouseDown += delegate
            {
                HMouseState = MouseState.DOWN; Invalidate();
            };
            MouseUp += delegate
            {
                HMouseState = MouseState.HOVER; Invalidate();
            };
            MouseMove += delegate (object sender, MouseEventArgs args)
            {
                MouseLocation = args.Location;
                var currentHoveredItem = GetItemAt(MouseLocation.X, MouseLocation.Y);
                if (HoveredItem != currentHoveredItem)
                {
                    HoveredItem = currentHoveredItem;
                    Invalidate();
                }
            };


        }



        List<Conlu> v;
        int LocationXColumnDisplayIndex(int displayIndex)
        {
            int a = 0;
            v = new List<Conlu>();
            for (int i = 0; i < Columns.Count; i++)
            {
                Conlu c = new Conlu();
                c.columnIndex = i; c.columnDisplayIndex = Columns[i].DisplayIndex; c.columnWidth = Columns[i].Width;
                v.Add(c);
            }
            for (int b = 0; b < displayIndex; b++)
                for (int i = 0; i < v.Count; i++)
                {
                    if (v[i].columnDisplayIndex == b)
                    {
                        a += v[i].columnWidth;
                    }
                }


            return a;
        }

        class Conlu
        {
            public int columnIndex { get; set; }
            public int columnDisplayIndex { get; set; }
            public int columnWidth { get; set; }
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            var g = e.Graphics; //GetAppResources.GetControlGraphicsEffect(g);
            g.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            int left = 0;
            if (InvokeRequired == false)
            {
                switch (View)
                {
                    case View.Details:
                        StringFormat SF = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near, Trimming = StringTrimming.EllipsisCharacter };
                      

                        for (int i = 0; i < e.Item.SubItems.Count;i++)
                        {
                            var subItem = e.Item.SubItems[i];
                            g.FillRectangle(new SolidBrush((e.Item.Selected) ? itemSelectedColor :
                            (e.Bounds.Contains(MouseLocation) && HMouseState == MouseState.HOVER) ? itemHoverColor : itemColor), subItem.Bounds.X,
                            subItem.Bounds.Y, subItem.Bounds.Width, subItem.Bounds.Height);
                            if (GridLines == true) g.DrawLine(new System.Drawing.Pen(new SolidBrush(dividerColor), 1), e.Bounds.Left, e.Bounds.Y, e.Bounds.Right, e.Bounds.Y);
                            if (CheckBoxes == true)
                            {

                                RectangleF recBox = new RectangleF(LocationXColumnDisplayIndex(Columns[0].DisplayIndex) + 4, subItem.Bounds.Y + subItem.Bounds.Height / 2 - 6, 14, 14);
                                left += (int)recBox.Width + 6;
                                g.FillRectangle(new SolidBrush(CheckBoxColor), recBox);
                                if (e.Item.Checked)
                                    g.DrawImage(CheckMarkBitmap(), new RectangleF(recBox.X - 1, recBox.Y - 1, recBox.Width, recBox.Height));

                                g.DrawRectangle(new Pen(new SolidBrush(BorderBoxColor)), Rectangle.Round(recBox));

                            }
                            if (i == 0)
                            {
                                if (Columns[0].Width > 0)
                                    g.DrawString(subItem.Text, itemFont, new SolidBrush(e.Item.Selected ? ItemTextSelectedColor :
                                                          (e.Bounds.Contains(MouseLocation) && HMouseState == MouseState.HOVER) ? ItemTextHoverColor : ItemTextColor),
                                                         new RectangleF(((i == 0) ? LocationXColumnDisplayIndex(Columns[0].DisplayIndex) : subItem.Bounds.X) + ((i == 0) ? left : 0), subItem.Bounds.Y + 4, ((i == 0) ? Columns[0].Width - ((i == 0) ? left : 0) : subItem.Bounds.Width), subItem.Bounds.Height - 8), SF);
                            }
                            else
                            {
                                g.DrawString(subItem.Text, itemFont, new SolidBrush(e.Item.Selected ? ItemTextSelectedColor :
                                                        (e.Bounds.Contains(MouseLocation) && HMouseState == MouseState.HOVER) ? ItemTextHoverColor : ItemTextColor),
                                                       new RectangleF((subItem.Bounds.X), subItem.Bounds.Y + 4, subItem.Bounds.Width, subItem.Bounds.Height - 8), SF);
                            }
                        }

                      
                        break;
                    case View.Tile:
                        break;
                }

            }

            base.OnDrawSubItem(e);
        }

        public Color ItemTextSelectedColor { get; set; } = Color.White;
        public Color ItemTextHoverColor { get; set; } = Color.WhiteSmoke;
        public Color CheckBoxColor { get; set; } = Color.WhiteSmoke;
        public Color BorderBoxColor { get; set; } = Color.DodgerBlue;
        public Color CheckMarkColor { get; set; } = Color.DodgerBlue;

   
        //protected override void OnDrawItem(DrawListViewItemEventArgs e)
        //{
        //    base.OnDrawItem(e);
        //    e.DrawBackground();
        //    //e.DrawDefault = false;
        //    var g = e.Graphics; //GetAppResources.GetControlGraphicsEffect(g);
        //    g.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
        //    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        //    int left = 0;
        //    if (InvokeRequired == false)
        //    {
      
        //        switch (View)
        //        {
        //            case View.Details:

        //                g.FillRectangle(new SolidBrush((e.Item.Selected) ? itemSelectedColor :
        //                (e.Bounds.Contains(MouseLocation) && HMouseState == MouseState.HOVER) ? itemHoverColor : itemColor), LocationXColumnDisplayIndex(Columns[0].DisplayIndex),
        //                e.Item.Bounds.Y, e.Item.Bounds.Width, e.Item.Bounds.Height);
        //                if (GridLines == true)
        //                // Draw separator line
        //                g.DrawLine(new System.Drawing.Pen(new SolidBrush(dividerColor), 1), e.Item.Bounds.Left, e.Item.Bounds.Y, e.Item.Bounds.Right, e.Item.Bounds.Y);
        //                StringFormat SF = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near, Trimming = StringTrimming.EllipsisCharacter };

        //                if (CheckBoxes == true)
        //                {

        //                    RectangleF recBox = new RectangleF(LocationXColumnDisplayIndex(Columns[0].DisplayIndex) + 4, e.Item.Bounds.Y + e.Item.Bounds.Height / 2 - 6, 14, 14);
        //                    left += (int)recBox.Width + 6;
        //                    g.FillRectangle(new SolidBrush(CheckBoxColor), recBox);
        //                    if (e.Item.Checked)
        //                        g.DrawImage(CheckMarkBitmap(), new RectangleF(recBox.X - 1, recBox.Y - 1, recBox.Width, recBox.Height));

        //                    g.DrawRectangle(new Pen(new SolidBrush(BorderBoxColor)), Rectangle.Round(recBox));

        //                }
        //                var subItem = e.Item;
        //                g.DrawString(subItem.Text, itemFont, new SolidBrush(e.Item.Selected ? ItemTextSelectedColor :
        //                    (e.Bounds.Contains(MouseLocation) && HMouseState == MouseState.HOVER) ? ItemTextHoverColor : ItemTextColor),
        //                    new RectangleF( LocationXColumnDisplayIndex(Columns[0].DisplayIndex) + left, e.Item.Bounds.Y + 4,  Columns[0].Width -  left - e.Item.Bounds.Width, e.Item.Bounds.Height));

        //                break;
        //            case View.Tile:
        //                break;
        //        }

        //    }

        //}

        static Point[] CHECKMARK_LINE = { new Point(3, 8), new Point(7, 12), new Point(14, 5) };

        private Bitmap CheckMarkBitmap()
        {
            var checkMark = new Bitmap(14, 14);
            checkMark.MakeTransparent();
            var g = Graphics.FromImage(checkMark);
            g.SmoothingMode = SmoothingMode.HighQuality;
            var pen = new Pen(new SolidBrush(CheckMarkColor), 2);
            g.DrawLines(pen, CHECKMARK_LINE);

            return checkMark;
        }


        private Font itemFont = new Font("Segoe UI", 12);
        public Font ItemFont
        {
            get { return itemFont; }
            set
            {
                itemFont = value; Invalidate();
            }
        }

        private Font headerFont = new Font("Segoe UI", 12);
        public Font HeaderFont
        {
            get { return headerFont; }
            set
            {
                headerFont = value; Invalidate();
            }
        }


        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
          
            e.DrawDefault = false;
            Graphics g = e.Graphics;
            GetAppResources.GetControlGraphicsEffect(g);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.FillRectangle(new SolidBrush(HeaderColor), e.Bounds);
            // Draw Text
            g.DrawString(e.Header.Text, headerFont, new SolidBrush(HeaderTextColor), new RectangleF(e.Bounds.X + 2, e.Bounds.Y,
                e.Bounds.Width - 4, e.Bounds.Height), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter });
            base.OnDrawColumnHeader(e);
        }

        private Color headerColor = Color.WhiteSmoke;
        /// <summary>
        /// Gets or sets Color for Header.
        /// </summary>
        public Color HeaderColor
        {
            get { return headerColor; }
            set
            {
                headerColor = value; Invalidate();
            }
        }

        private Color headerTextColor = Color.Black;
        /// <summary>
        /// Gets or sets Color for text  of Header.
        /// </summary>
        public Color HeaderTextColor
        {
            get { return headerTextColor; }
            set
            {
                headerTextColor = value; Invalidate();

            }
        }

        private Color itemColor = Color.LightGray;
        private Color itemHoverColor = Color.Silver;
        private Color itemSelectedColor = Color.Gainsboro;
        private Color dividerColor = Global.PrimaryColors.BackNormalColor1;
        private Color itemTextColor = Color.DodgerBlue;

        public Color ItemColor { get => itemColor; set { itemColor = value; Invalidate(); } }
        public Color ItemHoverColor { get => itemHoverColor; set { itemHoverColor = value; Invalidate(); } }
        public Color ItemSelectedColor { get => itemSelectedColor; set { itemSelectedColor = value; Invalidate(); } }
        public Color DividerColor { get => dividerColor; set { dividerColor = value; Invalidate(); } }
        public Color ItemTextColor { get => itemTextColor; set { itemTextColor = value; Invalidate(); } }

        // Resize
        protected override void OnColumnWidthChanging(ColumnWidthChangingEventArgs e)
        {
            base.OnColumnWidthChanging(e);
            AutoResize();
        }

        protected override void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {
            base.OnColumnWidthChanged(e);
            AutoResize();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AutoResize();
        }

        private void AutoResize()
        {
            if (!AutoSizeTable) return;

            // Width
            int w = 0;
            foreach (ColumnHeader col in Columns)
            {
                w += col.Width;
            }

            // Height
            int h = 50; //Header size
            if (Items.Count > 0) h = TopItem.Bounds.Top;
            foreach (ListViewItem item in Items)
            {
                h += item.Bounds.Height;
            }

            Size = new Size(w, h);
        }

    }
}