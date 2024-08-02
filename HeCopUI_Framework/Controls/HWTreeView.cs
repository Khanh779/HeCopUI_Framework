using HeCopUI_Framework.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;

namespace HeCopUI_Framework.Controls
{
    /// <summary>
    /// Class HTreeView
    /// Implements the <see cref="System.Windows.Forms.TreeView" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TreeView" />
    public partial class HWTreeView : System.Windows.Forms.TreeView
    {
        private Font _tipFont = new Font("Arial Unicode MS", 12f);
      
        private Color _nodeBackgroundColor = Color.White;
        private Color _nodeForeColor = Color.FromArgb(62, 62, 62);
        private Color _nodeSplitLineColor = Color.FromArgb(232, 232, 232);
        private Color m_nodeSelectedColor = Color.FromArgb(255, 77, 59);
        private Color m_nodeSelectedForeColor = Color.White;
        private bool showGridLines = true;

        public Font TipFont
        {
            get
            {
                return this._tipFont;
            }
            set
            {
                this._tipFont = value;
            }
        }


        public Color NodeBackgroundColor
        {
            get
            {
                return this._nodeBackgroundColor;
            }
            set
            {
                this._nodeBackgroundColor = value; Invalidate();
            }
        }

        public Color NodeForeColor
        {
            get
            {
                return this._nodeForeColor;
            }
            set
            {
                this._nodeForeColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [node is show split line].
        /// </summary>
        /// <value><c>true</c> if [node is show split line]; otherwise, <c>false</c>.</value>
        public bool ShowGridLines
        {
            get { return showGridLines; }
            set
            {
                showGridLines = value;
                Invalidate(); // Khi giá trị thay đổi, yêu cầu vẽ lại TreeView
            }
        }

        /// <summary>
        /// Gets or sets the color of the node split line.
        /// </summary>
        /// <value>The color of the node split line.</value>
        public Color NodeSplitLineColor
        {
            get
            {
                return this._nodeSplitLineColor;
            }
            set
            {
                this._nodeSplitLineColor = value; Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the node selected.
        /// </summary>
        /// <value>The color of the node selected.</value>
        public Color NodeSelectedColor
        {
            get
            {
                return this.m_nodeSelectedColor;
            }
            set
            {
                this.m_nodeSelectedColor = value; Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the node selected fore.
        /// </summary>
        /// <value>The color of the node selected fore.</value>
        public Color NodeSelectedForeColor
        {
            get
            {
                return this.m_nodeSelectedForeColor;
            }
            set
            {
                this.m_nodeSelectedForeColor = value; Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HWTreeView" /> class.
        /// </summary>
        public HWTreeView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray)) { Alignment= PenAlignment.Inset}, new Rectangle(0,0,Width-1, Height-1));
        }

        void NodePaint(DrawTreeNodeEventArgs e)
        {

            try
            {
                if (InvokeRequired == false)
                {
                    e.DrawDefault = false;

                    if (e.Node == null || (e.Node.Bounds.Width <= 0 && e.Node.Bounds.Height <= 0 && e.Node.Bounds.X <= 0 && e.Node.Bounds.Y <= 0))
                    {
                        //BeginUpdate();
                        return;
                    }   

                    if (e.State != TreeNodeStates.Indeterminate)
                    {
                        using (var BackNode = new SolidBrush(e.State == (TreeNodeStates.Selected | TreeNodeStates.Focused) ? this.m_nodeSelectedColor : this._nodeBackgroundColor))
                        using (var TextNode = new SolidBrush(e.State == (TreeNodeStates.Selected | TreeNodeStates.Focused) ? this.m_nodeSelectedForeColor : this._nodeForeColor))
                        {
                            var font = Font;
                            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            e.Graphics.TextRenderingHint = GetAppResources.SetTextRender();
                            SizeF textSize = e.Graphics.MeasureString(e.Node.Text, font);
                            float intLeft = 0;
                            if (CheckBoxes) intLeft = 20;
                            float num2 = 0;
                            intLeft += e.Node.Level * Indent + 18;
                            float a = intLeft - 18;
                            if (ImageList != null) intLeft += ImageList.ImageSize.Width;
                            
                            e.Graphics.FillRectangle(BackNode, new RectangleF(new PointF(0, e.Bounds.Y), new SizeF(Width, e.Bounds.Height)));
                            e.Graphics.DrawString(e.Node.Text, font, TextNode, (float)e.Bounds.X + intLeft + 4, (float)e.Bounds.Y + ((float)this.ItemHeight - textSize.Height) / 2f);
                            if (ImageList != null)
                            {
                                num2 = intLeft - ImageList.ImageSize.Width;
                                var imageSelected = e.Node.SelectedImageKey != String.Empty ? ImageList.Images[e.Node.SelectedImageKey] : ImageList.Images[e.Node.SelectedImageIndex];
                                var imageNormal = e.Node.SelectedImageKey != String.Empty ? ImageList.Images[e.Node.ImageKey] : ImageList.Images[e.Node.ImageIndex];
                                e.Graphics.DrawImage(e.State == (TreeNodeStates.Selected | TreeNodeStates.Focused) ? imageSelected : imageNormal, num2, e.Bounds.Y + (ItemHeight - ImageList.ImageSize.Height) / 2, ImageList.ImageSize.Width, ImageList.ImageSize.Height);
                            }
                            if (e.Node.Nodes.Count > 0)
                                e.Graphics.DrawImage(e.Node.IsExpanded ? Resources.list_add : Resources.more1, e.Bounds.X + a + 1, e.Bounds.Y + (ItemHeight - 16) / 2, 16, 16);
                            if (CheckBoxes)
                            {
                                var rectCheck = new Rectangle(e.Bounds.X + 3 + e.Node.Level * Indent, e.Bounds.Y + (ItemHeight - 16) / 2, 16, 16);
                                e.Graphics.FillRectangle(new SolidBrush(BackCheckBoxColor), rectCheck);

                                using (var pencheck = new Pen(new SolidBrush(CheckBoxColor), 1))
                                    e.Graphics.DrawRectangle(pencheck, rectCheck);
                                if (e.Node.Checked)
                                {
                                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                                    e.Graphics.DrawLines(new Pen(new SolidBrush(CheckedColor), 2), new Point[]
                                    {
                                new Point(rectCheck.Left+2,rectCheck.Top+8),
                                new Point(rectCheck.Left+6,rectCheck.Top+12),
                                new Point(rectCheck.Right-4,rectCheck.Top+4)
                                    });
                                }
                          
                            }
                        }
                    }

                    e.Graphics.SmoothingMode = SmoothingMode.Default;
                    var penchecka = new Pen(this._nodeSplitLineColor, 1f) { Alignment = PenAlignment.Center };
                    if (showGridLines)
                    {
                        e.Graphics.DrawLine(penchecka, new Point(0, e.Bounds.Y), new Point(Width, e.Bounds.Y));
                        // Sử dụng e.Bounds.Bottom thay vì e.Bounds.Y để vẽ đường lưới từ dưới lên
                        e.Graphics.DrawLine(penchecka, new Point(0, e.Bounds.Bottom), new Point(Width, e.Bounds.Bottom));
                    }
                    EndUpdate();
                }
                else
                {
                    BeginUpdate();
                }
            }
            catch
            {

            }


        }

        //protected override void OnBeforeCollapse(TreeViewCancelEventArgs e)
        //{
        //    Cursor = Cursors.WaitCursor;
        //    BeginUpdate();
        //    base.OnBeforeCollapse(e);
        //}

        //protected override void OnAfterCollapse(TreeViewEventArgs e)
        //{
        //    Cursor = Cursors.Default;
        //    EndUpdate();
        //    base.OnAfterCollapse(e);
        //}

        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            Cursor= Cursors.WaitCursor;
            BeginUpdate();
            base.OnBeforeExpand(e);
        }

        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            Cursor = Cursors.Default;
            EndUpdate();
            base.OnAfterExpand(e);
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            base.OnDrawNode(e);
            NodePaint(e);
        }

        public Color CheckBoxColor { get; set; } = Color.FromArgb(200, 200, 200);
        private Color bacCheckBoxColor = Color.FromArgb(247, 247, 247);

        public Color BackCheckBoxColor
        {
            get { return bacCheckBoxColor; }
            set
            {
                if (value == Color.Transparent) bacCheckBoxColor = Color.FromArgb(247, 247, 247);
                else bacCheckBoxColor = value;
                Invalidate();
            }
        }

        private Color checkedColor = Color.FromArgb(255, 77, 59);
        public Color CheckedColor
        {
            get { return checkedColor; }
            set
            {
                checkedColor = value;
                if (value == Color.Transparent)
                {
                    checkedColor = Color.FromArgb(255, 77, 59);
                }
                else checkedColor = value;
                Invalidate();
            }
        }

    }
}
