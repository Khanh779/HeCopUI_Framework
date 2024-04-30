

using System;
using System.Windows.Forms;

namespace HeCopUI_Framework.SuperNotifyIcon
{
    public partial class SuperNotifyIcon
    {
        // Activating the drop is done through this instead of something like a property "AllowDrop" because of the lag
        public void InitDrop(bool debug)
        {
            _formDrop = new FormDrop(this, debug);
        }
        public void InitDrop()
        {
            InitDrop(false);
        }

        // These don't attach/detach from the events in FormDrop as we should allow attaching and detaching even
        // when FormDrop isn't initialised.
        public event DragEventHandler DragDrop;
        public event DragEventHandler DragEnter;
        public event EventHandler DragLeave;
        public event DragEventHandler DragOver;

        internal void HandleDragDrop(object sender, DragEventArgs e)
        {
            if (DragDrop != null)
                DragDrop(sender, e);
        }

        internal void HandleDragEnter(object sender, DragEventArgs e)
        {
            if (DragEnter != null)
                DragEnter(sender, e);
        }

        internal void HandleDragLeave(object sender, EventArgs e)
        {
            if (DragLeave != null)
                DragLeave(sender, e);
        }

        internal void HandleDragOver(object sender, DragEventArgs e)
        {
            if (DragOver != null)
                DragOver(sender, e);
        }

        // Call 1-800-DropRefreshed
        public delegate void DropRefreshedEventHandler(object sender, DropRefreshedEventArgs e);
        public event DropRefreshedEventHandler DropRefreshed;

        internal void DropRefreshCallback(bool successful)
        {
            if (DropRefreshed != null)
                DropRefreshed(this, new DropRefreshedEventArgs() { Successful = successful });
        }
    }

    public class DropRefreshedEventArgs : EventArgs
    {
        public bool Successful { get; internal set; }
        public DropRefreshedEventArgs() { }
    }
}
