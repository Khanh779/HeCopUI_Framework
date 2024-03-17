using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeCopUI_Framework.HDialog
{
    public partial class HBrowserFileFolder : HeCopUI_Framework.Forms.HForm
    {
        public HBrowserFileFolder(string TitleText = "Browse For Files Or Folders", string Text = "", string Btn_OK = "OK", string Btn_Cancel = "Cancel")
        {
            InitializeComponent();

            //MaximumSize = new Size(this.Width, this.Height);
            //PB_Icon.Image = Icon.ToBitmap();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            AutoScaleMode = AutoScaleMode.Dpi;

            ShowInTaskbar = ShowIcon = false;
            LB_Info.Text = Text;
            if (LB_Info.Text == String.Empty) LB_Info.Visible = false;
            this.Text = TitleText;
            Btn_Scan.Text = Btn_OK;
            this.Btn_Cancel.Text = Btn_Cancel;
            this.Btn_Cancel.MouseClick += Btn_Cancel_MouseClick;
            this.Btn_Scan.MouseClick += Btn_Scan_MouseClick;
            Load += HBrowserFileFolder_Load;
        }

        private void HBrowserFileFolder_Load(object sender, EventArgs e)
        {
            LoadDir();
        }

        private void Btn_Scan_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                DialogResult = DialogResult.OK;
        }

        private void Btn_Cancel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                DialogResult = DialogResult.Cancel;
        }

        public new DialogResult Show()
        {
            base.ShowDialog();
            return DialogResult;
        }

        void LoadDir()
        {
            try
            {
                string[] drives = Directory.GetLogicalDrives();
                //_systemIcons.Add(0, 0);
                foreach (string drive in drives)
                {
                    DriveInfo di = new DriveInfo(drive);
                    TreeNode node = new TreeNode(drive);
                    node.Tag = drive;
                    imageList1.Images.Add(drive, ShellIcon.GetSmallIcon(drive));
                    //treeView1.ImageKey = node.Text;
                    node.ImageKey = drive;
                    node.SelectedImageKey = drive;
                    if (di.IsReady == true)
                    {
                        node.Nodes.Add("...");
                    }
                    treeView1.Nodes.Add(node);
                }
            }
            catch { }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle re = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Pen pen = new Pen(new SolidBrush(Color.Gray), 2);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.DrawRectangle(pen, re);
            base.OnPaint(e);
        }

     

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                e.Node.Nodes.Clear();
            }
            PopulateDirectory(e.Node.FullPath, e.Node).RunSynchronously();
        }

        private void BrowserFileFolder_Load(object sender, EventArgs e)
        {

        }

        Icon getIcon(string path)
        {
            Icon icon = ShellIcon.GetSmallIcon(path);
            //var a = icon.ToBitmap(); a.MakeTransparent();
            //icon= Icon.FromHandle(a.GetHicon());
            return icon;
        }


        private Task PopulateDirectory(string directory, TreeNode parentNode)
        {
            var a = new Task(() =>
            {
                try
                {
                    foreach (string dir in Directory.GetDirectories(directory))
                    {
                        try
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                            string fullPath = directoryInfo.FullName;
                            using (Icon icon = getIcon(fullPath))
                            {
                                imageList1.Images.Add(fullPath, icon);
                                TreeNode node = new TreeNode(Path.GetFileName(fullPath))
                                {
                                    ImageKey = fullPath,
                                    SelectedImageKey = fullPath
                                };
                                if (directoryInfo.GetDirectories().Count() > 0) node.Nodes.Add(null, "...", fullPath, fullPath);
                                if (ShowFiles)
                                    foreach (var fileInfo in directoryInfo.GetFiles())
                                    {
                                        string fileFullPath = fileInfo.FullName;
                                        using (Icon fileIcon = getIcon(fileFullPath))
                                        {
                                            imageList1.Images.Add(fileFullPath, fileIcon);
                                            TreeNode fileNode = new TreeNode(fileInfo.Name)
                                            {
                                                ImageKey = fileFullPath,
                                                SelectedImageKey = fileFullPath
                                            };
                                            node.Nodes.Add(fileNode);
                                        }
                                    }
                                parentNode.Nodes.Add(node);
                            }
                        }
                        catch { }
                    }

                    if (ShowFiles)
                        foreach (string filei in Directory.GetFiles(directory))
                        {
                            try
                            {
                                string fileFullPath = new FileInfo(filei).FullName;
                                using (Icon icon = getIcon(fileFullPath))
                                {
                                    imageList1.Images.Add(fileFullPath, icon);
                                    TreeNode node = new TreeNode(Path.GetFileName(fileFullPath))
                                    {
                                        ImageKey = fileFullPath,
                                        SelectedImageKey = fileFullPath
                                    };

                                    parentNode.Nodes.Add(node);
                                }
                            }
                            catch { }
                        }
                }
                catch { }
            });
            return a;
        }


        public string HPath = "";
        public string HFileName = "";
        public string HFolderName = "";

        // Comment chỗ showfiles để chỉ hiển thị folder

        /// <summary>
        /// Gets or sets a value indicating whether show files.
        /// </summary>

        public bool ShowFiles = true;
        FileInfo FI;
        DirectoryInfo DI;

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (File.Exists(e.Node.FullPath))
                {
                    FI = new FileInfo(e.Node.FullPath);
                    HPath = FI.FullName;
                    HFileName = FI.Name;
                }
                else
                {
                    DI = new DirectoryInfo(e.Node.FullPath);
                    HPath = DI.FullName;
                    HFolderName = DI.Name;
                }
            }
            catch { }
            if (e.Node.Checked == true) GetListPathChecked.Add(HPath);
            if (e.Node.Checked == false)
            {
                if (GetListPathChecked.Contains(HPath))
                {
                    GetListPathChecked.Remove(HPath);
                }
            }
        }

        public List<string> GetListPathChecked = new List<string>();

    }
}
