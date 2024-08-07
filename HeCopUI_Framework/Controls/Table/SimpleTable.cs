﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Utility_Tools.CustomControl.Table
{
    [ToolboxItem(true), DefaultProperty("Columns"), DefaultEvent("SelectionChanged")]
    public class SimpleTable : Control
    {

        private TableColumnCollection columns;
        TableRowCollection rows = new TableRowCollection();
        private int rowHeight = 20;
        int headerHeight = 25;

        bool reOrderable = true;

        private int draggingColumnIndex = -1;
        private int dragOffsetX = 0;
        private Bitmap dragBitmap;
        private Point dragPoint;

        Color gridColor = Color.Gainsboro;
        bool gridVisible = false;

        TableRowCollection selectedRow;
        TableRowCollection checkedRows;


        Color columnsBackColor = Color.FromArgb(56, 67, 87);
        Color rowsBackColor = Color.White;


        // Resize column
        private bool isResizingColumn = false;
        private int resizingColumnIndex = -1;
        private int initialColumnWidth = 0;
        private Point initialMouseLocation;



        bool acceptRowSelection = false;

        public bool AcceptRowSelection
        {
            get { return acceptRowSelection; }
            set
            {
                acceptRowSelection = value;
                this.Invalidate();
            }
        }

        private HeCopUI_Framework.Controls.ScrollBar.VScrollBar vScroll = new HeCopUI_Framework.Controls.ScrollBar.VScrollBar();
        HeCopUI_Framework.Controls.ScrollBar.HScrollBar hScroll = new HeCopUI_Framework.Controls.ScrollBar.HScrollBar();

        public SimpleTable()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw, true);

            columns = new TableColumnCollection(this);
            rows = new TableRowCollection();
            selectedRow = new TableRowCollection();
            checkedRows = new TableRowCollection();

            InitializeComponent();


        }



        private void InitializeComponent()
        {

            vScroll.Dock = DockStyle.Right;
            vScroll.Visible = false;
            vScroll.Value = 0;
            vScroll.Size = new Size(12, this.Height);
            vScroll.Scroll += VScroll_Scroll;

            hScroll.Visible = false;
            hScroll.Dock = DockStyle.Bottom;
            hScroll.Size = new Size(this.Width - (vScroll.Visible ? vScroll.Height : 0), 12);
            hScroll.Value = 0;
            hScroll.Scroll += HScroll_Scroll;

            Controls.Add(hScroll);
            this.Controls.Add(vScroll);
            UpdateScrollBar();


        }



        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            UpdateScrollBar();
        }

        public Color ColumnsBackColor
        {
            get { return columnsBackColor; }
            set
            {
                columnsBackColor = value;
                this.Invalidate();
            }
        }

        public Color RowsBackColor
        {
            get { return rowsBackColor; }
            set
            {
                rowsBackColor = value;
                this.Invalidate();
            }
        }


        public bool ReOrderable
        {
            get { return reOrderable; }
            set
            {
                reOrderable = value;
                this.Invalidate();
            }
        }

        public bool GridVisible
        {
            get { return gridVisible; }
            set
            {
                gridVisible = value;
                this.Invalidate();
            }
        }

        public Color GridColor
        {
            get { return gridColor; }
            set
            {
                gridColor = value;
                this.Invalidate();
            }
        }


        public int HeaderHeight
        {
            get { return headerHeight; }
            set
            {
                headerHeight = value;
                this.Invalidate();
            }
        }

        private bool allowUserResizeColumn = false;

        public bool AllowUserResizeColumn
        {
            get { return allowUserResizeColumn; }
            set
            {
                allowUserResizeColumn = value;
                Invalidate();
            }
        }


        public TableRow[] SelectedRows => selectedRow.ToArray();

        public TableRow[] CheckedRows => checkedRows.ToArray();

        [Localizable(true)]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TableColumnCollection Columns
        {
            get
            {
                OnColumnsChanged(EventArgs.Empty);
                UpdateScrollBar(); Invalidate(); return columns;
            }

        }

        [Localizable(true)]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TableRowCollection Rows
        {
            get
            {

                OnRowsChanged(EventArgs.Empty); UpdateScrollBar(); Refresh();
                return rows;
            }

        }



        [DefaultValue(20)]
        [Description("Height of each row")]
        public int RowHeight
        {
            get { return rowHeight; }
            set
            {
                rowHeight = value;
                UpdateScrollBar();
                this.Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate();
        }

        //int autoColWidth
        //{
        //    get
        //    {
        //        return columns != null && columns.Count > 0 ? (Width - (vScroll.Visible ? vScroll.Width : 0)) / columns.Count : 0;
        //    }
        //}


        internal int GetWidthThumb()
        {
            return (vScroll.Visible ? vScroll.Width : 0);
        }

        System.Drawing.Text.TextRenderingHint renderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return renderingHint; }
            set
            {
                renderingHint = value;
                this.Invalidate();
            }
        }



        Font headerFont = new Font("Arial", 11);

        public Font HeaderFont
        {
            get { return headerFont; }
            set
            {
                headerFont = value;
                this.Invalidate();
            }
        }

        Font rowFont = new Font("Arial", 10);
        public Font RowFont
        {
            get { return rowFont; }
            set
            {
                rowFont = value;
                this.Invalidate();
            }
        }

        // Color for split line of columns
        private Color splitLineColor = Color.LightGray;

        public Color SplitLineColor
        {
            get { return splitLineColor; }
            set
            {
                splitLineColor = value;
                this.Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (columns.Count == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, Width, Height);
                e.Graphics.DrawString("No columns found\nPlease add it", new Font("Arial", 12), new SolidBrush(Color.Black), new Rectangle(0, 0, Width, Height), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                return;
            }

            if (columns.Count == 0 || columns == null || rows == null) return;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderHint;


            int y = 0;
            int x = hScroll.Visible ? -hScroll.Value : 0;
            int sumAllColWidth = 0;


            using (var brushFillCol = new SolidBrush(columnsBackColor))
            using (var brushForeCol = new SolidBrush(columnsForeColor))
            using (Pen penSplitCol = new Pen(new SolidBrush(splitLineColor), 1))
            {
                e.Graphics.FillRectangle(brushFillCol, 0, 0, Width, HeaderHeight);
                foreach (var col in columns)
                {
                    Rectangle headerRect = new Rectangle(x, y, col.Width, HeaderHeight);
                    col.Bounds = new RectangleF(x, y, col.Width, HeaderHeight);


                    e.Graphics.FillRectangle(brushFillCol, headerRect);


                    e.Graphics.DrawString(col.Text, headerFont != null ? headerFont : Control.DefaultFont, brushForeCol, headerRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });


                    e.Graphics.DrawLine(penSplitCol, x + headerRect.Width, y, x + headerRect.Width, y + HeaderHeight);

                    x += col.Width;
                    sumAllColWidth += col.Width;
                }
            }


            y += HeaderHeight;


            Point s = PointToClient(MousePosition);

            Bitmap rowsBitmap = new Bitmap(Width - (vScroll != null && vScroll.Visible ? vScroll.Width : 0), Height - headerHeight - (hScroll.Visible ? hScroll.Height : 0));
            rowsBitmap.MakeTransparent();
            using (StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            })
            using (Graphics rg = Graphics.FromImage(rowsBitmap))
            {
                rg.TextRenderingHint = TextRenderHint;
                rg.SmoothingMode = SmoothingMode.HighQuality;
                rg.PixelOffsetMode = PixelOffsetMode.HighQuality;

                //Draw Rows and Columns

                int rowY = vScroll.Visible ? -vScroll.Value : 0;

                for (int i = 0; i < rows.Count; i++)
                {
                    x = hScroll.Visible ? -hScroll.Value : 0; // Đặt lại x cho từng dòng
                    rows[i].Bounds = new Rectangle(0, rowY, sumAllColWidth, rowHeight);
                    bool isHover = rows[i].Bounds.Contains(s.X, s.Y - headerHeight) && s.Y > headerHeight;

                    using (var fillBrush = new SolidBrush(rows[i].IsSelected ? rowsSelectedColor : isHover ? rowsHover : rowsBackColor))
                        rg.FillRectangle(fillBrush, rows[i].Bounds);

                    using (var brushCheckBack = new SolidBrush(checkBoxBack))
                    using (var brushCheckFore = new SolidBrush(checkIconColor))
                    using (var brush = new SolidBrush(rows[i].IsSelected ? rowsSelectedForeColor : isHover ? rowsHoverForeColor : rowsForeColor))
                    {
                        for (int j = 0; j < columns.Count; j++)
                        {
                            RectangleF cellRect = new RectangleF(x, rowY, columns[j].Width, rowHeight);

                            if (columns[j].Index == 0)
                            {
                                if (checkBoxVisible)
                                {
                                    RectangleF checkRect = new RectangleF(cellRect.X + 3, rowY + cellRect.Height / 2 - 7, 14, 14);
                                    rg.FillRectangle(brushCheckBack, checkRect);
                                    if (rows[i].CheckState == CheckState.Checked)
                                        using (var bitmapCheck = CheckSign(brushCheckFore))
                                            rg.DrawImage(bitmapCheck, checkRect.X, checkRect.Y);
                                }

                                if (imageVisible && rows[i].Image != null)
                                {
                                    var imageBou = new RectangleF(cellRect.X + (checkBoxVisible ? 17 : 0) + 2, cellRect.Y + cellRect.Height / 2 - ImageList.ImageSize.Height / 2, ImageList.ImageSize.Width, ImageList.ImageSize.Height);
                                    if (imageBou.Width >= 2)
                                    {
                                        rg.DrawImage(rows[i].Image, imageBou);
                                    }
                                }

                                var recta = new RectangleF(cellRect.X + (imageVisible ? ImageList.ImageSize.Width + 3 : 0) + (checkBoxVisible ? 17 : 0), cellRect.Y + 1, cellRect.Width -
                                   (checkBoxVisible ? 16 : 0) - (imageVisible ? ImageList.ImageSize.Width + 3 : 0), cellRect.Height - 1);
                                if (recta.Width >= 2)
                                {
                                    rg.DrawString(rows[i].Text, rowFont != null ? rowFont : Control.DefaultFont, brush, recta, sf);

                                }
                            }
                            else
                            {
                                if (cellRect.Width >= 2 && rows[i].SubRows != null && rows[i].SubRows.Count > columns[j].Index - 1)
                                {
                                    var subRow = rows[i].SubRows[columns[j].Index - 1];
                                    if (subRow != null)
                                    {
                                        rg.DrawString(subRow.Text, rowFont != null ? rowFont : Control.DefaultFont, brush, new RectangleF(cellRect.X, cellRect.Y + 1, cellRect.Width, cellRect.Height - 1), sf);
                                    }
                                }
                            }

                            x += columns[j].Width;
                        }
                    }



                    rowY += rowHeight;
                }

                if (gridVisible)
                {
                    using (var brushGrid = new SolidBrush(gridColor))
                    using (Pen pen = new Pen(brushGrid, 1))
                    {
                        //Vertical
                        for (int j = 0; j < columns.Count; j++)
                            rg.DrawLine(pen, columns[j].Bounds.X - 1, 0, columns[j].Bounds.X - 1, Height);
                        //Horizontal
                        for (int i = 0; i < rows.Count; i++)
                            rg.DrawLine(pen, 0, rows[i].Bounds.Y - 1, sumAllColWidth, rows[i].Bounds.Y - 1);
                    }
                }
            }

            // Draw Row
            e.Graphics.DrawImage(rowsBitmap, 0, y);

            rowsBitmap?.Dispose();

            // Draw dragging column
            if (draggingColumnIndex != -1 && dragBitmap != null && ReOrderable && isResizingColumn == false)
                e.Graphics.DrawImage(dragBitmap, dragPoint.X - dragOffsetX, 0);

            using (Pen penBorderTable = new Pen(Color.Black, 1) { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset })
                e.Graphics.DrawRectangle(penBorderTable, 0, 0, Width, Height);
        }


        Bitmap CheckSign(Brush signColor, int size = 14)
        {
            Bitmap bitmap = new Bitmap(size, size, PixelFormat.Format64bppPArgb);
            bitmap.MakeTransparent();
            using (Graphics g = Graphics.FromImage(bitmap))
            using (Pen pen = new Pen(signColor, 2))
            {
                size -= 2;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TranslateTransform((size + 2) / 2 - size / 2, (size + 2) / 2 - size / 2);
                g.DrawLine(pen, 1, size - 5, size / 2 - 1, size - 1);
                g.DrawLine(pen, size / 2 - 1, size - 1, size - 1, 1);
            }
            return bitmap;
        }


        bool imageVisible = false;

        public bool ImagesVisible
        {
            get { return imageVisible; }
            set
            {
                imageVisible = value;
                this.Invalidate();
            }
        }

        ImageList imageList = new ImageList();

        public void AddImage(string key, Image image)
        {
            imageList.Images.Add(key, image);
        }

        public void RemoveImage(string key)
        {
            imageList.Images.RemoveByKey(key);
        }

        public void RemoveImage(int index)
        {
            imageList.Images.RemoveAt(index);
        }

        public ImageList ImageList
        {
            get { return imageList; }
            set
            {
                imageList = value;
                Invalidate();
            }
        }

        bool checkBoxVisible = false;

        public bool CheckBoxVisible
        {
            get { return checkBoxVisible; }
            set
            {
                checkBoxVisible = value;
                this.Invalidate();
            }
        }

        Color checkBoxBack = Color.FromArgb(56, 67, 87);
        Color checkIconColor = Color.White;
        Color rowsForeColor = Color.Black;
        Color columnsForeColor = Color.White;

        public Color ColumnsForeColor
        {
            get { return columnsForeColor; }
            set
            {
                columnsForeColor = value;
                this.Invalidate();
            }
        }

        public Color RowsForeColor
        {
            get { return rowsForeColor; }
            set
            {
                rowsForeColor = value;
                this.Invalidate();
            }
        }

        public Color CheckBoxBackColor
        {
            get { return checkBoxBack; }
            set
            {
                checkBoxBack = value;
                this.Invalidate();
            }
        }

        public Color CheckColor
        {
            get { return checkIconColor; }
            set
            {
                checkIconColor = value;
                this.Invalidate();
            }
        }

        Color rowsHover = Color.Lavender;
        public Color RowsHoverBackColor
        {
            get { return rowsHover; }
            set
            {
                rowsHover = value;
                this.Invalidate();
            }
        }

        Color rowsSelectedColor = Color.FromArgb(102, 100, 252);
        public Color RowsSelectedBackColor
        {
            get { return rowsSelectedColor; }
            set
            {
                rowsSelectedColor = value;
                this.Invalidate();
            }
        }

        public Color RowsSelectedForeColor
        {
            get { return rowsSelectedForeColor; }
            set
            {
                rowsSelectedForeColor = value;
                this.Invalidate();
            }
        }

        Color rowsSelectedForeColor = Color.White;

        Color rowsHoverForeColor = Color.Black;

        public Color RowsHoverForeColor
        {
            get { return rowsHoverForeColor; }
            set
            {
                rowsHoverForeColor = value;
                this.Invalidate();
            }
        }

        Color RevertColor(Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!DesignMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.Y <= HeaderHeight && ReOrderable)
                    {
                        int x = (hScroll.Visible ? -hScroll.Value : 0);
                        for (int i = 0; i < columns.Count; i++)
                        {
                            int colWidth = columns[i].Width;
                            if (e.X >= x && e.X <= x + colWidth)
                            {
                                draggingColumnIndex = i;
                                dragOffsetX = e.X - x;

                                dragBitmap?.Dispose();
                                dragBitmap = new Bitmap(colWidth, HeaderHeight);
                                dragBitmap.MakeTransparent();
                                Color hintBack = RevertColor(columnsBackColor);
                                Color hintFore = RevertColor(columnsForeColor);
                                using (var brushBackHign = new SolidBrush(Color.FromArgb(140, hintBack)))
                                using (var brushForeHign = new SolidBrush(Color.FromArgb(140, hintFore)))
                                using (Graphics g = Graphics.FromImage(dragBitmap))
                                {
                                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                    g.TextRenderingHint = TextRenderHint;
                                    Rectangle headerRect = new Rectangle(0, 0, colWidth, HeaderHeight);
                                    g.FillRectangle(brushBackHign, headerRect);
                                    g.DrawString(columns[i].Text, headerFont, brushForeHign, headerRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                                }
                                dragPoint = e.Location;
                                break;
                            }
                            x += colWidth;
                        }
                    }

                    if (allowUserResizeColumn && e.Y <= HeaderHeight)
                    {
                        int x = (hScroll.Visible ? -hScroll.Value : 0);
                        for (int i = 0; i < columns.Count; i++)
                        {
                            int colWidth = columns[i].Width;
                            if (e.X >= x + colWidth - 2 && e.X <= x + colWidth + 2)
                            {
                                isResizingColumn = true;
                                resizingColumnIndex = i;
                                initialMouseLocation = e.Location;
                                initialColumnWidth = colWidth;
                                break;
                            }
                            x += colWidth;
                        }
                    }
                }

            }
        }



        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!DesignMode)
            {
                if (draggingColumnIndex != -1 && ReOrderable && !isResizingColumn)
                {
                    dragPoint = e.Location;
                    int newLeft = e.X - dragOffsetX;
                    int colWidth = columns[draggingColumnIndex].Width;
                    int newIndex = newLeft / colWidth;
                    if (newIndex != draggingColumnIndex && newIndex < columns.Count)
                    {
                        var col = columns[draggingColumnIndex];
                        columns.RemoveAt(draggingColumnIndex);
                        columns.Insert(newIndex, col);
                        //columns[newIndex].DisplayIndex = newIndex;
                        draggingColumnIndex = newIndex;

                    }
                }


                if (allowUserResizeColumn)
                {
                    Cursor cursor = Cursors.Default;
                    int x = (hScroll.Visible ? -hScroll.Value : 0);
                    for (int i = 0; i < columns.Count; i++)
                    {
                        int colWidth = columns[i].Width;
                        if (e.X >= x + colWidth - 2 && e.X <= x + colWidth + 2 && e.Y <= headerHeight)
                        {
                            cursor = Cursors.SizeWE;
                            break;
                        }

                        x += colWidth;
                    }
                    Cursor = cursor;

                    if (isResizingColumn && resizingColumnIndex != -1 && e.Y <= headerHeight)
                    {
                        int newWidth = initialColumnWidth + (e.X - initialMouseLocation.X - (hScroll.Visible ? hScroll.Value : 0));
                        if (newWidth > 0)
                        {
                            columns[resizingColumnIndex].Width = newWidth;
                            UpdateScrollBar();
                            //this.Invalidate();
                        }
                    }
                }
                this.Invalidate();
            }
        }



        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (!DesignMode)
            {
                var mousePo = new Point(e.Location.X, e.Location.Y - headerHeight);
                if (e.Y > HeaderHeight)
                {
                    if (acceptRowSelection || checkBoxVisible)
                    {
                        for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
                        {

                            var row = rows[rowIndex];
                            if (row.Bounds.Contains(mousePo))
                            {
                                if (checkBoxVisible)
                                {
                                    int x = 0;
                                    for (int col = 0; col < columns.Count; col++)
                                    {
                                        int colWidth = columns[col].Width;

                                        if (columns[col].Index == 0 && checkBoxVisible)
                                        {
                                            var checkRect = new RectangleF(x + 1, row.Bounds.Y + rowHeight / 2 - 7, 14, 14);
                                            if (checkRect.Contains(mousePo))
                                            {
                                                rows[rowIndex].CheckState = rows[rowIndex].CheckState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked;
                                                Invalidate();
                                                OnCheckedChanged(EventArgs.Empty);
                                                return; // Exit the method to avoid toggling the selection state
                                            }
                                        }
                                        x += colWidth;
                                    }

                                }

                                if (acceptRowSelection == true)
                                {
                                    if (selectedRow.Contains(row))
                                    {
                                        row.IsSelected = false;
                                        selectedRow.Remove(row);
                                    }
                                    else
                                    {
                                        row.IsSelected = true;
                                        selectedRow.Add(row);
                                    }
                                    Invalidate();
                                }

                                OnSelectionChanged(EventArgs.Empty);
                            }
                        }
                    }
                }
            }
        }

        public event EventHandler ColumnsChanged;
        protected virtual void OnColumnsChanged(EventArgs e)
        {

            ColumnsChanged?.Invoke(this, e);
        }

        public event EventHandler SelectionChanged;
        protected virtual void OnSelectionChanged(EventArgs e) => SelectionChanged?.Invoke(this, e);

        public event EventHandler CheckedChanged;
        protected virtual void OnCheckedChanged(EventArgs e) => CheckedChanged?.Invoke(this, e);

        public event EventHandler RowsChanged;
        protected virtual void OnRowsChanged(EventArgs e)
        {

            UpdateScrollBar();
            RowsChanged?.Invoke(this, e);
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!DesignMode)
            {
                if (draggingColumnIndex != -1)
                {
                    draggingColumnIndex = -1;

                    dragBitmap = null;
                    this.Invalidate();
                }

                if (isResizingColumn)
                {
                    isResizingColumn = false;
                    resizingColumnIndex = -1;
                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (!DesignMode)
            {
                if (vScroll.Visible)
                {
                    int newVal = vScroll.Value - (e.Delta / 120 * SystemInformation.MouseWheelScrollLines) * rowHeight;
                    if (newVal < vScroll.Minimum)
                    {
                        newVal = vScroll.Minimum;
                    }
                    if (newVal > vScroll.Maximum - vScroll.LargeChange)
                    {
                        newVal = vScroll.Maximum - vScroll.LargeChange;
                    }
                    vScroll.Value = newVal;


                    UpdateScrollBar();
                }
            }

            Invalidate();
        }

        private void VScroll_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScrollBar();
            Invalidate();
        }

        private void HScroll_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScrollBar();
            Invalidate();
        }

        public int ScrollValue
        {
            get { return vScroll.Value; }
            set
            {
                vScroll.Value = value;
                Invalidate();
            }
        }

        public int ScrollMaximum => vScroll.Maximum;

        public int ScrollMinimum => vScroll.Minimum;

        private void UpdateScrollBar()
        {
            if (rows != null && vScroll != null)
            {
                int totalHeight = rows.Count * rowHeight;
                int clientAreaHeight = this.Height - headerHeight;
                vScroll.Visible = totalHeight > clientAreaHeight;
                if (vScroll.Visible)
                {
                    vScroll.LargeChange = rowHeight;
                    vScroll.Maximum = totalHeight - clientAreaHeight + rowHeight;
                }

            }

            if (columns != null && hScroll != null)
            {
                int totalWidth = columns.Sum(x => x.Width);
                int clientAreaWidth = this.Width - (vScroll.Visible ? vScroll.Width : 0);
                hScroll.Visible = totalWidth > clientAreaWidth;
                if (hScroll.Visible)
                {
                    hScroll.LargeChange = columns.Count > 0 ? columns.Min(x => x.Width) : 10;
                    hScroll.Maximum = totalWidth - clientAreaWidth;
                }

            }
        }



    }

}
