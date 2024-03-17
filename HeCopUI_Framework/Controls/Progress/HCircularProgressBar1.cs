using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Progress
{
    [ToolboxBitmap(typeof(HCircularProgressBar1), "Bitmaps.CircleProgress.bmp")]
    public partial class HCircularProgressBar1 : Control
    {

        #region Enums

#pragma warning disable CS3008 // Identifier is not CLS-compliant
        public enum _ProgressShape
#pragma warning restore CS3008 // Identifier is not CLS-compliant
        {
            Round,
            Flat
        }

        #endregion
        #region Variables

        private long _Value;
        private long _Maximum = 100;
        private Color _ProgressColor1 = Color.FromArgb(92, 92, 92);
        private Color _ProgressColor2 = Color.FromArgb(92, 92, 92);
        private _ProgressShape ProgressShapeVal;

        #endregion
        #region Custom Properties

        public long Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                _Value = value;
                Invalidate();
            }
        }

        public long Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                _Maximum = value;
                Invalidate();
            }
        }

        public Color ProgressColor1
        {
            get { return _ProgressColor1; }
            set
            {
                _ProgressColor1 = value;
                Invalidate();
            }
        }

        public Color ProgressColor2
        {
            get { return _ProgressColor2; }
            set
            {
                _ProgressColor2 = value;
                Invalidate();
            }
        }

        public _ProgressShape ProgressShape
        {
            get { return ProgressShapeVal; }
            set
            {
                ProgressShapeVal = value;
                Invalidate();
            }
        }

        #endregion
        #region EventArgs

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetStandardSize();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
        }

        protected override void OnPaintBackground(PaintEventArgs p)
        {
            base.OnPaintBackground(p);
        }

        #endregion

        public HCircularProgressBar1()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            BackColor = Color.Transparent;
            Size = new Size(130, 130);
            Font = new Font("Segoe UI", 15);
            MinimumSize = new Size(100, 100);
            ForeColor = Color.FromArgb(64, 64, 64);
            ProgressColor1 = ProgressColor2 = Global.PrimaryColors.ProgressBarColor1;
            DoubleBuffered = true;
        }

        private void SetStandardSize()
        {
            int _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        public void Increment(int Val)
        {
            this._Value += Val;
            Invalidate();
        }

        public void Decrement(int Val)
        {
            this._Value -= Val;
            Invalidate();
        }

        private Color CenteC1 = Global.PrimaryColors.BaseProgressBarColor1;
        private Color CenteC2 = Global.PrimaryColors.BaseProgressBarColor1;
        public Color BaseColor1
        {
            get { return CenteC1; }
            set
            {
                CenteC1 = value; Invalidate();
            }
        }

        public Color BaseColor2
        {
            get { return CenteC2; }
            set
            {
                CenteC2 = value; Invalidate();
            }
        }

        private float bordw = 8;
        public float ProgressThickness
        {
            get { return bordw; }
            set
            {
                bordw = value; Invalidate();
            }
        }

        private System.Drawing.Text.TextRenderingHint textRenderHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return textRenderHint; }
            set
            {
                textRenderHint = value; Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Bitmap bitmap = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format64bppPArgb))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    e.Graphics.TextRenderingHint = TextRenderHint;
                    GetAppResources.GetControlGraphicsEffect(graphics);
                    graphics.TextRenderingHint = TextRenderHint;
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.Clear(this.BackColor);
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this._ProgressColor1, this._ProgressColor2, LinearGradientMode.ForwardDiagonal))
                    {
                        using (Pen pen = new Pen(brush, bordw))
                        {
                            switch (this.ProgressShapeVal)
                            {
                                case _ProgressShape.Round:
                                    pen.StartCap = LineCap.Round;
                                    pen.EndCap = LineCap.Round;
                                    break;

                                case _ProgressShape.Flat:
                                    pen.StartCap = LineCap.Flat;
                                    pen.EndCap = LineCap.Flat;
                                    break;
                            }
                            graphics.DrawArc(pen, 0x12, 0x12, (this.Width - 0x23) - 2, (this.Height - 0x23) - 2, -90, (int)Math.Round((double)((360.0 / ((double)this._Maximum)) * this._Value)));
                        }
                    }
                    using (LinearGradientBrush brush2 = new LinearGradientBrush(this.ClientRectangle, CenteC1, CenteC2, LinearGradientMode.Vertical))
                    {
                        graphics.FillEllipse(brush2, 0x18, 0x18, (this.Width - 0x30) - 1, (this.Height - 0x30) - 1);
                    }

                    StringFormat SF = new StringFormat();
                    SF.Alignment = SF.LineAlignment = StringAlignment.Center;
                    switch (TT)
                    {
                        case TextType.Value:
                            graphics.DrawString(_Value.ToString(), Font, new SolidBrush(ForeColor), ClientRectangle, SF);
                            break;
                        case TextType.Percentage:
                            graphics.DrawString(_Value.ToString() + "%", Font, new SolidBrush(ForeColor), ClientRectangle, SF);
                            break;
                    }
                    e.Graphics.DrawImage(bitmap, 0, 0);
                    graphics.Dispose();
                    bitmap.Dispose();
                }
            }
        }

        public enum TextType
        {
            Value, Percentage, None
        }

        private TextType TT = TextType.Percentage;
        public TextType ProgresTextType
        {
            get { return TT; }
            set
            {
                TT = value; Invalidate();
            }
        }
    }
}