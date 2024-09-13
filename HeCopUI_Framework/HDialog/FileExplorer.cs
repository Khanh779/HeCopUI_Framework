using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.HDialog
{
    public partial class FileExplorer : Forms.HForm
    {
        public FileExplorer()
        {
            InitializeComponent();
            Load += FileExplorer_Load;
        }

        void LoadDir()
        {
            try
            {
                treeView1.BeginInvoke((Action)delegate
                {
                    string[] drives = Directory.GetLogicalDrives();
                    //_systemIcons.Add(0, 0);
                    foreach (string drive in drives)
                    {
                        DriveInfo di = new DriveInfo(drive);
                        TreeNode node = new TreeNode(drive);
                        node.Tag = drive;
                        imageList1.Images.Add(drive, ShellIcon.GetLargeIcon(drive));
                        //treeView1.ImageKey = node.Text;
                        node.ImageKey = drive;
                        node.SelectedImageKey = drive;
                        if (di.IsReady == true)
                        {
                            node.Nodes.Add("...");
                        }
                        treeView1.Nodes.Add(node);
                    }
                });
            }
            catch { }
        }


        private void FileExplorer_Load(object sender, EventArgs e)
        {
            hComboBox1.Location = new Point(label1.Location.X + label1.Size.Width + 5, hComboBox1.Location.Y);

            hComboBox1.DataSource = Enum.GetValues(typeof(View));
            hComboBox1.Text = hListView1.View.ToString();
            hComboBox1.SelectedValueChanged += HComboBox1_SelectedValueChanged;
            LoadDir();
        }

        private void HComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            hListView1.View = (View)hComboBox1.SelectedItem;
        }

        #region asd load file and folder
        void asd(TreeViewCancelEventArgs e)
        {
            try
            {
                if (e.Node.Nodes.Count > 0)
                {
                    if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                    {
                        e.Node.Nodes.Clear();

                        //get the list of sub direcotires
                        string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                        //add files of rootdirectory
                        DirectoryInfo rootDir = new DirectoryInfo(e.Node.Tag.ToString());

                        foreach (string dir in dirs)
                        {
                            DirectoryInfo di = new DirectoryInfo(dir);
                            TreeNode node = new TreeNode(di.Name);
                            Icon icfo = ShellIcon.GetSmallIcon(dir); ;
                            imageList1.Images.Add(dir, icfo);
                            node.ImageKey = dir;
                            node.SelectedImageKey = dir;
                            try
                            {
                                //keep the directory's full path in the tag for use later
                                node.Tag = dir;

                                //if the directory has sub directories add the place holder
                                if (di.GetDirectories().Count() > 0)
                                {
                                    treeView1.BeginUpdate();
                                    node.Nodes.Add(null, "...", dir, dir);
                                    treeView1.EndUpdate();
                                }

                            }
                            catch (UnauthorizedAccessException)
                            {
                                node.SelectedImageKey = dir;
                                node.ImageKey = dir;
                            }
                            finally
                            {
                                treeView1.BeginUpdate();
                                e.Node.Nodes.Add(node);
                                treeView1.EndUpdate();
                            }
                        }

                    }
                }
            }
            catch { }

        }
        #endregion

        void PopulateNode(TreeNode treeNode)
        {
            try
            {
                treeNode.Nodes.Clear();
                string[] directories = Directory.GetDirectories(treeNode.Tag.ToString());
                string[] files = Directory.GetFiles(treeNode.Tag.ToString());
                foreach (string directory in directories)
                {
                    try
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                        TreeNode directoryNode = new TreeNode(directoryInfo.Name);
                        directoryNode.Tag = directory;
                        Icon icfo = ShellIcon.GetSmallIcon(directory);
                        imageList1.Images.Add(directory, icfo);
                        directoryNode.ImageKey = directory;
                        directoryNode.SelectedImageKey = directory;
                        if (directoryInfo.GetDirectories().Count() > 0)
                        {
                            directoryNode.Nodes.Add(null, "...", directory, directory);
                        }
                        treeNode.Nodes.Add(directoryNode);
                    }
                    catch { }
                }

            }
            catch (UnauthorizedAccessException)
            {
                // Handle unauthorized access exception if needed
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            treeView1.BeginUpdate();
            treeView1.Invoke((Action)delegate
            {

                e.Node.Nodes.Clear();
                e.Node.Nodes.Add("...");
                PopulateNode(e.Node);
                //asd(e);
            });
            treeView1.EndUpdate();
            Cursor = Cursors.Default;
        }

        //[DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        //private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            hListView1.Invoke((Action)delegate
            {
                hListView1.Items.Clear();
                try
                {
                    foreach (var files in Directory.GetFiles(e.Node.FullPath))
                    {
                        try
                        {
                            FileInfo FI = new FileInfo(files);
                            imageList2.Images.Add(FI.FullName, HDialog.ShellIcon.GetSmallIcon(FI.FullName));

                            ListViewItem LC = new ListViewItem(new string[] { FI.Name, FI.Extension,
                            GetAppResources.StringSizeOfFile(FI.Length), FI.LastWriteTime.ToString()});
                            LC.ImageKey = FI.FullName;
                            hListView1.Items.Add(LC);

                        }
                        catch { }
                    }

                }
                catch { }
            });
            htmlLabel1.Text = String.Format(@"<div><font color=""rgb(0, 168, 142)""><b>{0}</b></font> file(s) in directory (<font color=""rgb(0, 168, 148)""><b>{1}</b></font>).</div>",
                               hListView1.Items.Count.ToString(), new DirectoryInfo(e.Node.FullPath).Name);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Forms.HMessageBox.Show("Do you want to open this file.", "Question", Forms.HMessageBox.Buttons.YesNo,
                 Forms.HMessageBox.HIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    foreach (ListViewItem a in hListView1.SelectedItems)
                        Process.Start(treeView1.SelectedNode.FullPath + "\\" + a.Text);
                }
                catch
                {
                    Forms.HMessageBox.Show("Access is denied!", "Error", Forms.HMessageBox.Buttons.OK,
                         Forms.HMessageBox.HIcon.Error);
                }
            }
        }

        #region file's properties dialog

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
#pragma warning disable CS3003 // Type is not CLS-compliant
            public uint fMask;
#pragma warning restore CS3003 // Type is not CLS-compliant
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
#pragma warning disable CS3003 // Type is not CLS-compliant
            public uint dwHotKey;
#pragma warning restore CS3003 // Type is not CLS-compliant
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;
        #endregion
        public static bool ShowFileProperties(string Filename)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = Filename;
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            return ShellExecuteEx(ref info);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem a in hListView1.SelectedItems)
                {
                    ShowFileProperties(treeView1.SelectedNode.FullPath + "\\" + a.Text);
                }
            }
            catch
            {
                Forms.HMessageBox.Show("Access is denied!", "Error", Forms.HMessageBox.Buttons.OK,
                     Forms.HMessageBox.HIcon.Error);
            }
        }

        private void openInWindowsExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(treeView1.SelectedNode.FullPath);
            }
            catch
            {
                Forms.HMessageBox.Show("Access is denied!", "Error", Forms.HMessageBox.Buttons.OK,
                     Forms.HMessageBox.HIcon.Error);
            }
        }
    }
}
