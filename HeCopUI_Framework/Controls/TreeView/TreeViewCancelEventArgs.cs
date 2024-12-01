using System.ComponentModel;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.TreeView
{
    public class TreeViewCancelEventArgs : CancelEventArgs
    {
        private TreeNode node;

        private TreeViewAction action;


        public TreeNode Node => node;


        public TreeViewAction Action => action;

        public TreeViewCancelEventArgs(TreeNode node)
        {
            this.node = node;
        }

        public TreeViewCancelEventArgs(TreeNode node, bool cancel, TreeViewAction action)
            : base(cancel)
        {
            this.node = node;
            this.action = action;
        }
    }
}
