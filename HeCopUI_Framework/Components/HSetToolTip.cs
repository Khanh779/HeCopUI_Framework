using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace HeCopUI_Framework.Components
{

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HSetToolTip), "Bitmaps.ToolTip.bmp")]

    [DefaultEvent("Popup")]
    public class HSetToolTip : ToolTip
    {






        #region Constructors

        public HSetToolTip()
        {
            OwnerDraw = true;
            Draw += OnDraw;
            Popup += ToolTip_Popup;

        }

        #endregion Constructors

        #region Draw Control


        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            var rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1);
            using (var bg = new SolidBrush(BackColor))
            using (var stroke = new Pen(BorderColor))
            using (var tb = new SolidBrush(ForeColor))
            {
                //System.Drawing.Drawing2D.GraphicsPath GP = new HeCop_UI_Tools.GetAppResources.MyRectangle(e.Bounds.Width - 1, e.Bounds.Height - 1, 5, 0, 0).Path;
                g.FillRectangle(bg, rect);
                //g.FillPath(bg, GP);
                //System.Drawing.Drawing2D.GraphicsPath gp = new GetAppResources.MyRectangle(e.AssociatedControl.Width, e.AssociatedControl.Height, 8, 0, 0).Path;
                //g.FillPath(bg, gp);
                TextSize = g.MeasureString(e.ToolTipText, TipFont);
                g.DrawString(e.ToolTipText, TipFont, tb, rect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                g.DrawRectangle(stroke, rect);
            }

        }

        SizeF TextSize;

        public Font TipFont { get; set; } = new Font("Tahoma", 10);

        #endregion



        #region Properties



        /// <summary>
        /// Gets or sets the border color for the ToolTip.
        /// </summary>
        [Description("Gets or sets the border color for the ToolTip.")]
        public Color BorderColor { get; set; }

        private bool _isDerivedStyle = true;

        /// <summary>
        /// Gets or sets the whether this control reflect to parent form style.
        /// Set it to false if you want the style of this control be independent. 
        /// </summary>
        [Description("Gets or sets the whether this control reflect to parent(s) style. \n " +
                     "Set it to false if you want the style of this control be independent. ")]
        public bool IsDerivedStyle
        {
            get { return _isDerivedStyle; }
            set
            {
                _isDerivedStyle = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The ToolTip text to display when the pointer is on the control.
        /// </summary>
        /// <param name = "control" > The Control to show the tooltip.</param>
        /// <param name = "caption" > The Text that appears in tooltip.</param>
        public new void SetToolTip(Control control, string caption)
        {
            //This Method is useful at runtime.
            base.SetToolTip(control, caption);
        }

        #endregion

        #region Events 

        /// <summary>
        /// Here we handle popup event and we set the style of controls for tooltip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolTip_Popup(object sender, PopupEventArgs e)
        {
            //e.ToolTipSize.Width + 30, e.ToolTipSize.Height + 6
            e.ToolTipSize = new Size(e.ToolTipSize.Width + 30, e.ToolTipSize.Height + 6);
        }

        #endregion

    }
}