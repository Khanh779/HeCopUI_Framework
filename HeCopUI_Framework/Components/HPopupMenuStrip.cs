
using static HeCopUI_Framework.Win32.User32;
using HeCopUI_Framework.Components;
using HeCopUI_Framework.Win32;
using HeCopUI_Framework.Win32.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace HeCopUI_Framework.Components
{
    /// <summary>
    /// Represents a pop-up window.
    /// </summary>
    //[CLSCompliant(true), ToolboxItem(false)]
    public partial class HPopupMenuStrip : ToolStripDropDown
    {
        #region " Fields & Properties "

        /// <summary>
        /// Gets the content of the pop-up.
        /// </summary>
        public Control Content { get; private set; }

        /// <summary>
        /// Determines which animation to use while showing the pop-up window.
        /// </summary>
        public PopupAnimations ShowingAnimation { get; set; }

        /// <summary>
        /// Determines which animation to use while hiding the pop-up window.
        /// </summary>
        public PopupAnimations HidingAnimation { get; set; }

        /// <summary>
        /// Determines the duration of the animation.
        /// </summary>
        public int AnimationDuration { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether the content should receive the focus after the pop-up has been opened.
        /// </summary>
        /// <value><c>true</c> if the content should be focused after the pop-up has been opened; otherwise, <c>false</c>.</value>
        /// <remarks>If the FocusOnOpen property is set to <c>false</c>, then pop-up cannot use the fade effect.</remarks>
        public bool FocusOnOpen { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether pressing the alt key should close the pop-up.
        /// </summary>
        /// <value><c>true</c> if pressing the alt key does not close the pop-up; otherwise, <c>false</c>.</value>
        public bool AcceptAlt { get; set; }

        private ToolStripControlHost _host;
        private Control _opener;
        private HPopupMenuStrip _ownerPopup;
        private HPopupMenuStrip _childPopup;
        private bool _resizableTop;
        private bool _resizableLeft;

        private bool _isChildPopupOpened;
        private bool _resizable;
        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="HeCopUI_Framework.Popup" /> is resizable.
        /// </summary>
        /// <value><c>true</c> if resizable; otherwise, <c>false</c>.</value>
        public bool Resizable
        {
            get { return _resizable && !_isChildPopupOpened; }
            set { _resizable = value; }
        }

        private bool _nonInteractive;
        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="HeCopUI_Framework.Popup"></see> acts like a transparent windows (so it cannot be clicked).
        /// </summary>
        /// <value>
        /// <c>true</c> if the popup is noninteractive; otherwise, <c>false</c>.</value>
        public bool NonInteractive
        {
            get { return _nonInteractive; }
            set
            {
                if (value != _nonInteractive)
                {
                    _nonInteractive = value;
                    if (IsHandleCreated) RecreateHandle();
                }
            }
        }

        /// <summary>
        /// Gets or sets a minimum size of the pop-up.
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        public new Size MinimumSize { get; set; }

        /// <summary>
        /// Gets or sets a maximum size of the pop-up.
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        public new Size MaximumSize { get; set; }

        /// <summary>
        /// Gets parameters of a new window.
        /// </summary>
        /// <returns>An object of type <see cref="T:System.Windows.Forms.CreateParams" /> used when creating a new window.</returns>
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams cp = base.CreateParams;
                //cp.ExStyle |= NativeMethods.WS_EX_NOACTIVATE|
                //  GetAppResources.Win32.HParams.WS_EX_LAYERED|
                //NativeMethods.WS_EX_TRANSPARENT;
                cp.ExStyle = cp.ExStyle | 0x20;
                //if (NonInteractive==true) cp.ExStyle |= NativeMethods.WS_EX_TRANSPARENT | NativeMethods.WS_EX_LAYERED;//| NativeMethods.WS_EX_TOOLWINDOW;
                return cp;
            }
        }

        #endregion



        #region " Constructors "

        /// <summary>
        /// Initializes a new instance of the <see cref="HeCopUI_Framework.Popup"/> class.
        /// </summary>
        /// <param name="content">The content of the pop-up.</param>
        /// <remarks>
        /// Pop-up will be disposed immediately after disposion of the content control.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="content" /> is <code>null</code>.</exception>
        public HPopupMenuStrip(Control content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }
            Content = content;
            FocusOnOpen = true;
            ShowingAnimation = PopupAnimations.SystemDefault;
            HidingAnimation = PopupAnimations.None;
            AnimationDuration = 100;
            DropShadowEnabled = false;
            AutoSize = false;
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            AllowTransparency = true;
            ResizeRedraw = true;
            _host = new ToolStripControlHost(content);
            _host.BackColor = Color.Transparent;
            Padding = Margin = _host.Padding = _host.Margin = Padding.Empty;
            if (IsRunningOnMono) content.Margin = Padding.Empty;
            MinimumSize = content.MinimumSize;
            content.MinimumSize = content.Size;
            MaximumSize = content.MaximumSize;
            content.MaximumSize = content.Size;
            Size = content.Size;
            if (IsRunningOnMono) _host.Size = content.Size;
            TabStop = content.TabStop = true;
            content.Location = Point.Empty;
            Items.Add(_host);
            //content.RegionChanged += (sender, e) => UpdateRegion();
            Paint += HPopupMenuStrip_Paint;
            //UpdateRegion();
        }

        private void HPopupMenuStrip_Paint(object sender, PaintEventArgs e)
        {
            OnPaintBackground(e);
        }


        #endregion

        #region " Methods "

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripItem.VisibleChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
          
            if ((Visible && ShowingAnimation == PopupAnimations.None) || (!Visible && HidingAnimation == PopupAnimations.None))
            {
                return;
            }
            HeCopUI_Framework.Win32.Enums.AnimationFlags flags = Visible ? HeCopUI_Framework.Win32.Enums.AnimationFlags.Roll : HeCopUI_Framework.Win32.Enums.AnimationFlags.Hide;
            PopupAnimations _flags = Visible ? ShowingAnimation : HidingAnimation;
            if (_flags == PopupAnimations.SystemDefault)
            {
                if (SystemInformation.IsMenuAnimationEnabled)
                {
                    if (SystemInformation.IsMenuFadeEnabled)
                    {
                        _flags = PopupAnimations.Blend;
                    }
                    else
                    {
                        _flags = PopupAnimations.Slide | (Visible ? PopupAnimations.TopToBottom : PopupAnimations.BottomToTop);
                    }
                }
                else
                {
                    _flags = PopupAnimations.None;
                }
            }
            if ((_flags & (PopupAnimations.Blend | PopupAnimations.Center | PopupAnimations.Roll | PopupAnimations.Slide)) == PopupAnimations.None)
            {
                return;
            }
            if (_resizableTop) // popup is “inverted”, so the animation must be
            {
                if ((_flags & PopupAnimations.BottomToTop) != PopupAnimations.None)
                {
                    _flags = (_flags & ~PopupAnimations.BottomToTop) | PopupAnimations.TopToBottom;
                }
                else if ((_flags & PopupAnimations.TopToBottom) != PopupAnimations.None)
                {
                    _flags = (_flags & ~PopupAnimations.TopToBottom) | PopupAnimations.BottomToTop;
                }
            }
            if (_resizableLeft) // popup is “inverted”, so the animation must be
            {
                if ((_flags & PopupAnimations.RightToLeft) != PopupAnimations.None)
                {
                    _flags = (_flags & ~PopupAnimations.RightToLeft) | PopupAnimations.LeftToRight;
                }
                else if ((_flags & PopupAnimations.LeftToRight) != PopupAnimations.None)
                {
                    _flags = (_flags & ~PopupAnimations.LeftToRight) | PopupAnimations.RightToLeft;
                }
            }
            flags = flags | (HeCopUI_Framework.Win32.Enums  .AnimationFlags.Mask & (HeCopUI_Framework.Win32.Enums.AnimationFlags)(int)_flags);
            SetForegroundWindow(this.Handle);
            Win32.User32.AnimateWindow(this.Handle, AnimationDuration, (int)flags);
        }

        /// <summary>
        /// Processes a dialog box key.
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>
        /// true if the key was processed by the control; otherwise, false.
        /// </returns>
        [UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (AcceptAlt && ((keyData & Keys.Alt) == Keys.Alt))
            {
                if ((keyData & Keys.F4) != Keys.F4)
                {
                    return false;
                }
                else
                {
                    Close();
                }
            }
            bool processed = base.ProcessDialogKey(keyData);
            if (!processed && (keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Shift)))
            {
                bool backward = (keyData & Keys.Shift) == Keys.Shift;
                Content.SelectNextControl(null, !backward, true, true, true);
            }
            return processed;
        }


        /// <summary>
        /// Shows the pop-up window below the specified control.
        /// </summary>
        /// <param name="control">The control below which the pop-up will be shown.</param>
        /// <remarks>
        /// When there is no space below the specified control, the pop-up control is shown above it.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="control"/> is <code>null</code>.</exception>
        public void Show(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            Show(control, control.ClientRectangle);
        }

        /// <summary>
        /// Shows the pop-up window below the specified area.
        /// </summary>
        /// <param name="area">The area of desktop below which the pop-up will be shown.</param>
        /// <remarks>
        /// When there is no space below specified area, the pop-up control is shown above it.
        /// </remarks>
        public void Show(Rectangle area)
        {
            _resizableTop = _resizableLeft = false;
            Point location = new Point(area.Left, area.Top + area.Height);
            Rectangle screen = Screen.FromControl(this).WorkingArea;
            if (location.X + Size.Width > (screen.Left + screen.Width))
            {
                _resizableLeft = true;
                location.X = (screen.Left + screen.Width) - Size.Width;
            }
            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                _resizableTop = true;
                location.Y -= Size.Height + area.Height;
            }
            //location = control.PointToClient(location);
            Show(location, ToolStripDropDownDirection.BelowRight);
        }

        /// <summary>
        /// Shows the pop-up window below the specified area of the specified control.
        /// </summary>
        /// <param name="control">The control used to compute screen location of specified area.</param>
        /// <param name="area">The area of control below which the pop-up will be shown.</param>
        /// <remarks>
        /// When there is no space below specified area, the pop-up control is shown above it.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="control"/> is <code>null</code>.</exception>
        public void Show(Control control, Rectangle area)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            SetOwnerItem(control);

            _resizableTop = _resizableLeft = false;
            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            Rectangle screen = Screen.FromControl(control).WorkingArea;
            if (location.X + Size.Width > (screen.Left + screen.Width))
            {
                _resizableLeft = true;
                location.X = (screen.Left + screen.Width) - Size.Width;
            }
            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                _resizableTop = true;
                location.Y -= Size.Height + area.Height;
            }
            location = control.PointToClient(location);
            Show(control, location, ToolStripDropDownDirection.BelowRight);
        }



        private void SetOwnerItem(Control control)
        {
            if (control == null)
            {
                return;
            }
            if (control is HPopupMenuStrip)
            {
                HPopupMenuStrip popupControl = control as HPopupMenuStrip;
                _ownerPopup = popupControl;
                _ownerPopup._childPopup = this;
                OwnerItem = popupControl.Items[0];
                return;
            }
            else if (_opener == null)
            {
                _opener = control;
            }
            if (control.Parent != null)
            {
                SetOwnerItem(control.Parent);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (Content != null)
            {
                Content.MinimumSize = Size;
                Content.MaximumSize = Size;
                Content.Size = Size;
                Content.Location = Point.Empty;
            }
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Layout" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.LayoutEventArgs" /> that contains the event data.</param>
        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            Size suggestedSize = GetPreferredSize(Size.Empty);
            if (AutoSize && suggestedSize != Size)
            {
                Size = suggestedSize;
            }
            SetDisplayedItems();
            OnLayoutCompleted(EventArgs.Empty);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripDropDown.Opening" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs" /> that contains the event data.</param>
        protected override void OnOpening(CancelEventArgs e)
        {
            if (Content.IsDisposed || Content.Disposing)
            {
                e.Cancel = true;
                return;
            }
            //UpdateRegion();
            base.OnOpening(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripDropDown.Opened" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnOpened(EventArgs e)
        {
            if (_ownerPopup != null)
            {
                _ownerPopup._isChildPopupOpened = true;
            }
            if (FocusOnOpen)
            {
                Content.Focus();
            }
            base.OnOpened(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripDropDown.Closed"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripDropDownClosedEventArgs"/> that contains the event data.</param>
        protected override void OnClosed(ToolStripDropDownClosedEventArgs e)
        {
            _opener = null;
            if (_ownerPopup != null)
            {
                _ownerPopup._isChildPopupOpened = false;
            }
            base.OnClosed(e);
        }

        #endregion

        #region " Resizing Support "

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == NativeMethods.WM_PRINT && !Visible)
            //{
            //    Visible = true;
            //}
            if (InternalProcessResizing(ref m, false))
            {
                return;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Processes the resizing messages.
        /// </summary>
        /// <param name="m">The message.</param>
        /// <returns>true, if the WndProc method from the base class shouldn't be invoked.</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool ProcessResizing(ref Message m)
        {
            return InternalProcessResizing(ref m, true);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool InternalProcessResizing(ref Message m, bool contentControl)
        {
            if (m.Msg == (int)HeCopUI_Framework.Win32.Enums.WindowMessages.WM_NCACTIVATE && m.WParam != IntPtr.Zero && _childPopup != null && _childPopup.Visible)
            {
                _childPopup.Hide();
            }
            if (!Resizable && !NonInteractive)
            {
                return false;
            }
            if (m.Msg == (int)HeCopUI_Framework.Win32.Enums.WindowMessages.WM_NCHITTEST)
            {
                return OnNcHitTest(ref m, contentControl);
            }
            else if (m.Msg == (int)HeCopUI_Framework.Win32.Enums.WindowMessages.WM_GETMINMAXINFO)
            {
                return OnGetMinMaxInfo(ref m);
            }
            return false;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool OnGetMinMaxInfo(ref Message m)
        {
            Win32.Struct.MINMAXINFO minmax = (Win32.Struct.MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(Win32.Struct.MINMAXINFO));
            if (!MaximumSize.IsEmpty)
            {
                minmax.maxTrackSize = MaximumSize;
            }
            minmax.minTrackSize = MinimumSize;
            Marshal.StructureToPtr(minmax, m.LParam, false);
            return true;
        }

        private bool OnNcHitTest(ref Message m, bool contentControl)
        {
            if (NonInteractive)
            {
                m.Result = (IntPtr)Win32.Enums.HitTests.HTTRANSPARENT;
                return true;
            }

            int x = Cursor.Position.X; // NativeMethods.LOWORD(m.LParam);
            int y = Cursor.Position.Y; // NativeMethods.HIWORD(m.LParam);
            Point clientLocation = PointToClient(new Point(x, y));

            GripBounds gripBouns = new GripBounds(contentControl ? Content.ClientRectangle : ClientRectangle);
            IntPtr transparent = new IntPtr((int)Win32.Enums.HitTests.HTTRANSPARENT);

            if (_resizableTop)
            {
                if (_resizableLeft && gripBouns.TopLeft.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)Win32.Enums.HitTests.HTTOPLEFT;
                    return true;
                }
                if (!_resizableLeft && gripBouns.TopRight.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)Win32.Enums.HitTests.HTTOPRIGHT;
                    return true;
                }
                if (gripBouns.Top.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)Win32.Enums.HitTests.HTTOP;
                    return true;
                }
            }
            else
            {
                if (_resizableLeft && gripBouns.BottomLeft.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)Win32.Enums.HitTests.HTBOTTOMLEFT;
                    return true;
                }
                if (!_resizableLeft && gripBouns.BottomRight.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)Win32.Enums.HitTests.HTBOTTOMRIGHT;
                    return true;
                }
                if (gripBouns.Bottom.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)Win32.Enums.HitTests.HTBOTTOM;
                    return true;
                }
            }
            if (_resizableLeft && gripBouns.Left.Contains(clientLocation))
            {
                m.Result = contentControl ? transparent : (IntPtr)Win32.Enums.HitTests.HTLEFT;
                return true;
            }
            if (!_resizableLeft && gripBouns.Right.Contains(clientLocation))
            {
                m.Result = contentControl ? transparent : (IntPtr)Win32.Enums.HitTests.HTRIGHT;
                return true;
            }
            return false;
        }


        #endregion

        internal struct GripBounds
        {
            private const int GripSize = 6;
            private const int CornerGripSize = GripSize << 1;

            public GripBounds(Rectangle clientRectangle)
            {
                this.clientRectangle = clientRectangle;
            }

            private Rectangle clientRectangle;
            public Rectangle ClientRectangle
            {
                get { return clientRectangle; }
                //set { clientRectangle = value; }
            }

            public Rectangle Bottom
            {
                get
                {
                    Rectangle rect = ClientRectangle;
                    rect.Y = rect.Bottom - GripSize + 1;
                    rect.Height = GripSize;
                    return rect;
                }
            }

            public Rectangle BottomRight
            {
                get
                {
                    Rectangle rect = ClientRectangle;
                    rect.Y = rect.Bottom - CornerGripSize + 1;
                    rect.Height = CornerGripSize;
                    rect.X = rect.Width - CornerGripSize + 1;
                    rect.Width = CornerGripSize;
                    return rect;
                }
            }

            public Rectangle Top
            {
                get
                {
                    Rectangle rect = ClientRectangle;
                    rect.Height = GripSize;
                    return rect;
                }
            }

            public Rectangle TopRight
            {
                get
                {
                    Rectangle rect = ClientRectangle;
                    rect.Height = CornerGripSize;
                    rect.X = rect.Width - CornerGripSize + 1;
                    rect.Width = CornerGripSize;
                    return rect;
                }
            }

            public Rectangle Left
            {
                get
                {
                    Rectangle rect = ClientRectangle;
                    rect.Width = GripSize;
                    return rect;
                }
            }

            public Rectangle BottomLeft
            {
                get
                {
                    Rectangle rect = ClientRectangle;
                    rect.Width = CornerGripSize;
                    rect.Y = rect.Height - CornerGripSize + 1;
                    rect.Height = CornerGripSize;
                    return rect;
                }
            }

            public Rectangle Right
            {
                get
                {
                    Rectangle rect = ClientRectangle;
                    rect.X = rect.Right - GripSize + 1;
                    rect.Width = GripSize;
                    return rect;
                }
            }

            public Rectangle TopLeft
            {
                get
                {
                    Rectangle rect = ClientRectangle;
                    rect.Width = CornerGripSize;
                    rect.Height = CornerGripSize;
                    return rect;
                }
            }
        }
    }
}
