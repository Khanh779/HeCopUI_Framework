using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.TreeView
{
    public class TreeNode
    {
        [Bindable(false), Browsable(false)]
        public HTreeView Owner { get; internal set; }

        [Bindable(false), Browsable(false)]
        public TreeNode Parent { get; set; }

        public string Text { get; set; }
        public object Tag { get; set; }
        public string Name { get; set; }
        public int Index { get; set; } = -1;
        public bool IsSelected = false;

        bool isExpanded = false;
        [Browsable(false)]
        public bool IsExpanded
        {
            get
            {
                return isExpanded;
            }
            set
            {
                isExpanded = value;
                Owner?.Refresh();
            }
        }

        [Browsable(false)]
        public bool IsRoot => Parent == null;

        [Browsable(false)]
        public bool IsLeaf => Nodes.Count == 0;


        bool isFocused = false;
        [Browsable(false)]
        public bool IsFocused
        {
            get { return isFocused; }
            set
            {
                if (value && Parent != null)
                {
                    SetIsFocused(Parent.Nodes);
                    SetIsFocused(Nodes);
                    Parent.Owner?.Refresh();
                }

                isFocused = value;
                Owner?.Refresh();
            }
        }


        public int ImageIndex { get; set; } = -1;

        [Browsable(false)]
        public string FullPath
        {
            get
            {
                if (Parent == null)
                {
                    return Text;
                }

                string pathSeparator = Owner?.PathSeparator ?? Parent.Owner?.PathSeparator ?? "\\";
                string parentFullPath = Parent.FullPath;

                if (parentFullPath.EndsWith(pathSeparator))
                {
                    parentFullPath = parentFullPath.TrimEnd(pathSeparator.ToCharArray());
                }

                return parentFullPath + pathSeparator + Text;
            }
        }

        void SetIsFocused(TreeNodeCollection nodes)
        {
            foreach (TreeNode _node in nodes)
            {
                _node.IsFocused = false;
            }
        }

        [Browsable(false)]
        public TreeNode PreviousNode
        {
            get
            {
                if (Parent == null)
                    return null;

                int index = Parent.Nodes.IndexOf(this);
                if (index > 0)
                {
                    return Parent.Nodes[index - 1];
                }
                return null;
            }
        }

        [Browsable(false)]
        public TreeNode NextNode
        {
            get
            {
                if (Parent == null)
                    return null;

                int index = Parent.Nodes.IndexOf(this);
                if (index >= 0 && index < Parent.Nodes.Count - 1)
                {
                    return Parent.Nodes[index + 1];
                }
                return null;
            }
        }

        [Browsable(false)]
        public TreeNode FirstNode => Nodes.Count > 0 ? Nodes[0] : null;

        [Browsable(false)]
        public TreeNode LastNode => Nodes.Count > 0 ? Nodes[Nodes.Count - 1] : null;

        public CheckState CheckState = CheckState.Unchecked;

        public bool Checked
        {
            get => CheckState == CheckState.Checked;
            set
            {
                CheckState = value ? CheckState.Checked : CheckState.Unchecked;
                Owner?.Invalidate();
            }
        }

        public Font Font { get; set; } = null;

        private TreeNodeCollection nodes;

        [Localizable(true)]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TreeNodeCollection Nodes => nodes;

        public TreeNode this[int index] => Nodes[index];

        public Image Image { get; set; } = null;
        public Rectangle Bounds = Rectangle.Empty;

        public TreeNode()
        {
            nodes = new TreeNodeCollection(this);
        }

        public TreeNode(string text) : this()
        {
            Text = text;
        }

        public TreeNode(TreeNode node) : this()
        {
            Text = node.Text;
            Tag = node.Tag;
            Name = node.Name;
            ImageIndex = node.ImageIndex;
            foreach (TreeNode child in node.Nodes)
            {
                Nodes.Add(new TreeNode(child));
            }
        }
    }
}
