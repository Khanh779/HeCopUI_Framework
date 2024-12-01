using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.ListControl
{
    public partial class HComboBox : ComboBox
    {
        public HComboBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            BackColor = Color.Transparent;
            //AllowDrop = true;
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 20;
            base.FlatStyle = FlatStyle.Flat;
            CausesValidation = false;
            base.DropDownStyle = ComboBoxStyle.DropDownList;

        }



        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ComboBoxStyle DropDownStyle { get; set; } = ComboBoxStyle.DropDownList;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new FlatStyle FlatStyle { get; set; } = FlatStyle.Flat;


        private Color it = Color.White;
        public Color SelectedItemForeColor
        {
            get { return it; }
            set
            {
                it = value; Invalidate();
            }
        }

        private Color ita = Color.FromArgb(80, 80, 80);
        public Color ItemForeColor
        {
            get { return ita; }
            set
            {
                ita = value; Invalidate();
            }
        }

        private Color itb = Color.FromArgb(0, 168, 148);
        public Color SelectedItemBackColor
        {
            get { return itb; }
            set
            {
                itb = value; Invalidate();
            }
        }

        private Font IFo = Control.DefaultFont;
        public Font ItemsFont
        {
            get { return IFo; }
            set
            {
                IFo = value; Invalidate();
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            var g = e.Graphics;
            e.DrawBackground();
            g.TextRenderingHint = textRendering;

            if (e.Index == -1)
            {
                return;
            }

            var sf = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center,
                Trimming = st
            };

            var itemState = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            using (var bg = new SolidBrush(itemState ? SelectedItemBackColor : BackgroundColor))
            using (var tc = new SolidBrush(itemState ? SelectedItemForeColor : ItemForeColor))
            {
                SizeF a = g.MeasureString(GetItemText(Items[e.Index]), IFo);
                g.FillRectangle(bg, e.Bounds);
                g.DrawString(GetItemText(Items[e.Index]), ItemsFont, tc, new RectangleF(
                    e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), sf);
            }

            //g.DrawRectangle(new Pen(new SolidBrush(SelectedItemBackColor), 1) { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset },
            // new Rectangle(0, 0, DropDownWidth, DropDownHeight));
            g.Dispose();
            base.OnDrawItem(e);
        }



        /*protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            HeCopUI_Framework.GetAppResources.GetControlGraphicsEffect(e.Graphics);
            e.Graphics.TextRenderingHint = textRendering;

            for (int i = 0; i < e.Index - 1;i++)
            {
                e.Graphics.DrawString(Items[i].ToString(), Font, new SolidBrush(it), 0, , null);
            }
            base.OnMeasureItem(e);
        }*/



        System.Drawing.Text.TextRenderingHint textRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        public System.Drawing.Text.TextRenderingHint TextRendergHint
        {
            get { return textRendering; }
            set
            {
                textRendering = value; Invalidate();
            }
        }





        private Color bc = Global.PrimaryColors.BorderNormalColor1;
        public Color BorderColor
        {
            get { return bc; }
            set
            {
                bc = value; Invalidate();
            }
        }

        private Color bacg = Color.White;
        public Color BackgroundColor
        {
            get { return bacg; }
            set
            {
                bacg = value; Invalidate();
            }
        }

        private Color dis = Color.WhiteSmoke;
        public Color DisabledBackColor
        {
            get { return dis; }
            set
            {
                dis = value; Invalidate();
            }
        }

        private Color bdis = Color.FromArgb(60, 60, 60);
        public Color DisabledBorderColor
        {
            get { return bdis; }
            set
            {
                bdis = value; Invalidate();
            }
        }


        private Color att = Color.FromArgb(0, 168, 118);
        public Color ArrowColor
        {
            get { return att; }
            set
            {
                att = value; Invalidate();
            }
        }

        private Color df = Color.FromArgb(64, 64, 64);
        public Color DisabledForeColor
        {
            get { return df; }
            set
            {
                df = value; Invalidate();
            }
        }

        private StringTrimming st = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return st; }
            set
            {
                st = value; Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            var downArrow = '▼';
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            g.TextRenderingHint = textRendering;
            sf.Trimming = st;

            using (var bg = new SolidBrush(Enabled ? BackgroundColor : DisabledBackColor))
            {
                using (var p = new Pen(Enabled ? BorderColor : DisabledBorderColor, 1) { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset })
                {
                    using (var s = new SolidBrush(Enabled ? ArrowColor : DisabledForeColor))
                    {
                        using (var tb = new SolidBrush(Enabled ? SelectedItemBackColor : DisabledForeColor))
                        {
                            g.FillRectangle(bg, rect);
                            SizeF b = g.MeasureString(downArrow.ToString(), new Font(Font.Name, 10f));
                            g.DrawString(downArrow.ToString(), new Font(Font.Name, 10f), s,
                                new RectangleF(Width - 18, 0, b.Width, Height), sf);

                            g.DrawString(Text, Font, tb, new RectangleF(4, 1, Width - 1 - b.Width, Height - 2),
                               sf);
                            g.DrawRectangle(p, rect);
                        }
                    }
                }
            }
            //g.Dispose();
            if (go)
            {
                g.DrawRectangle(new Pen(new SolidBrush(FocusBorderColor), 1f)
                {
                    Alignment = System.Drawing.Drawing2D.PenAlignment.Inset,
                    DashStyle = dashStyle
                }, new Rectangle(2, 2, Width - 5, Height - 5));
            }

            base.OnPaint(e);
        }

        bool go = false;
        protected override void OnEnter(EventArgs e)
        {
            go = true;
            Invalidate();
            base.OnEnter(e);
        }

        private DashStyle dashStyle = DashStyle.Dot;
        public DashStyle DashStyle
        {
            get { return dashStyle; }
            set
            {
                dashStyle = value; Invalidate();
            }
        }

        public Color FocusBorderColor { get; set; } = Color.DodgerBlue;

        protected override void OnLeave(EventArgs e)
        {
            go = false;
            Invalidate();

            base.OnLeave(e);
        }
    }
}
