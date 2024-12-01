using System;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.TreeView
{
    public class TreeViewEventArgs : EventArgs
    {
        TreeNode node;

        TreeViewAction action;

        public TreeNode Node => node;

        public TreeViewAction Action => action;

        public TreeViewEventArgs(TreeNode node)
        {
            this.node = node;
        }

        public TreeViewEventArgs(TreeNode node, TreeViewAction action) : this(node)
        {
            this.node = node;
            this.action = action;
        }
    }
}
