using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    [ToolboxBitmap(typeof(Label), "Bitmaps.Label.bmp")]
    public partial class HLabel : Control
    {
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [SettingsBindable(true)]
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;Invalidate();
            }
        }

        public HLabel()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            BackColor = Color.Transparent;
        }


        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            Invalidate();
            base.OnFontChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            Invalidate();
            base.OnForeColorChanged(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GetAppResources.GetControlGraphicsEffect(g);
            StringFormat SF = new StringFormat();
            SF.Trimming = ST;
            g.TextRenderingHint = textRen;
            GetAppResources.GetStringAlign(SF, CA);
            if((_symbol != String.Empty || _symbol != null | _symbol != "") && symbolVisible)
                g.DrawString(_symbol, _symbolFont, new SolidBrush(_symbolColor), new RectangleF(0 + Padding.Left, 0 + Padding.Top, Width - Padding.Right, Height - Padding.Bottom));
            g.DrawString(Text, Font, new SolidBrush(ForeColor), new RectangleF(((_symbol!=String.Empty|| _symbol!=null | _symbol!="")? g.MeasureString(_symbol, _symbolFont).Width+2 :  0) + Padding.Left, 
                0 + Padding.Top, Width - Padding.Right - ((_symbol != String.Empty || _symbol != null | _symbol != "") ? g.MeasureString(_symbol, _symbolFont).Width + 2 : 0), Height - Padding.Bottom), SF);
            base.OnPaint(e);
        }

        bool symbolVisible = true;

        /// <summary>
        /// Gets or sets symbol visibility
        /// </summary>
        public bool SymbolVisible
        {
            get { return symbolVisible; }
            set
            {
                symbolVisible = value; Invalidate();
            }
        }

        Color _symbolColor = Color.Gray;

        /// <summary>
        /// Gets or sets symbol color
        /// </summary>
        public Color SymbolColor
        {
            get { return _symbolColor; }
            set
            {
                _symbolColor = value; Invalidate();
            }
        }

        private System.Drawing.Text.TextRenderingHint textRen = GetAppResources.SetTextRender();
        public System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get { return textRen; }
            set
            {
                textRen = value;
            }
        }

        Font _symbolFont=new Font("Segoe UI Emoji", 10);
        public Font SymbolFont
        {
            get { return _symbolFont; }
            set
            {
                _symbolFont = value; Invalidate();
            }
        }

        string _symbol = "";
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value; Invalidate();
            }
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            Invalidate();
            base.OnPaddingChanged(e);
        }

        private StringTrimming ST = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return ST; }
            set
            {
                ST = value; Invalidate();
            }
        }

        private ContentAlignment CA = ContentAlignment.MiddleCenter;
        public ContentAlignment TextAlign
        {
            get { return CA; }
            set
            {
                CA = value; Invalidate();
            }
        }
    }
}
