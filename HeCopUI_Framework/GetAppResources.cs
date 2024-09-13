using HeCopUI_Framework.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HeCopUI_Framework
{
    public partial class GetAppResources
    {
   
        #region Run Instance
        public static void ShowInstanceProcess(Form MainForm, string ApplicationName, bool BringWindowToFront)
        {
            Mutex mutext = new Mutex(true, ApplicationName, out bool CreaN);
            if (CreaN == true)
                Application.Run(MainForm);
            else
            {
                if (BringWindowToFront == true)
                {
                    Process currentProcess = Process.GetCurrentProcess();
                    // Check with other process already running   
                    foreach (var p in Process.GetProcesses())
                    {
                        if (p.Id != currentProcess.Id && p.ProcessName.Equals(currentProcess.ProcessName) == true) // Check running process   
                        {
                            IntPtr hFound = p.MainWindowHandle;
                            if (HeCopUI_Framework.Win32.User32.IsIconic(hFound)) // If application is in ICONIC mode then  
                                HeCopUI_Framework.Win32.User32.ShowWindow(hFound, HeCopUI_Framework.Win32.Enums.ShowWindowStyles.SW_RESTORE);
                            HeCopUI_Framework.Win32.User32.SetForegroundWindow(hFound); // Activate the window, if process is already running  
                        }
                    }
                }
            }
            mutext.ReleaseMutex();
        }

        #endregion

        #region AssemblyGuid
        public static string AssemblyGuid
        {
            get
            {
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
                if (attributes.Length == 0)
                {
                    return String.Empty;
                }
                return ((System.Runtime.InteropServices.GuidAttribute)attributes[0]).Value;
            }
        }
        #endregion

        #region Effect Animation

        public enum Effect { Roll, Slide, Center, Blend }

        public static void Animate(Control ctl, Effect effect, int msec, int angle)
        {
            int flags = effmap[(int)effect];
            if (ctl.Visible) { flags |= 0x10000; angle += 180; }
            else
            {
                if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                else if (effect == Effect.Blend) throw new ArgumentException();
            }
            flags |= dirmap[(angle % 360) / 45];
            bool ok = HeCopUI_Framework.Win32.User32.AnimateWindow(ctl.Handle, msec, flags);
            if (!ok) throw new Exception("Animation failed");
            ctl.Visible = !ctl.Visible;
        }


        private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };
        private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

        #endregion

        #region Order
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1">Number 1 is Padding 1 of controls.</param>
        /// <param name="num2">Number 2 is Padding 2 of controls.</param>
        /// <param name="num3">Number 3 is Padding 3 of controls.</param>
        /// <param name="num4">Number 4 is Padding 4 of controls.</param>
        /// <returns></returns>
        public int SizeGetMaxPad(int num1, int num2, int num3, int num4)
        {
            //int re = 0;
            //if (Math.Max(num1, num2) > num2) re = num1;
            //else if (Math.Max(num1, num2) < num2) re = num2;
            //else if (Math.Max(num1, num3) > num3) re = num1;
            //else if (Math.Max(num1, num3) < num3) re = num3;
            //else if (Math.Max(num1, num4) > num4) re = num1;
            //else if (Math.Max(num1, num4) < num4) re = num4;

            //if (Math.Max(num2, num3) > num3) re = num2;
            //else if (Math.Max(num2, num3) < num3) re = num3;
            //if (Math.Max(num2, num4) > num4) re = num2;
            //else if (Math.Max(num2, num4) < num4) re = num4;
            //if (Math.Max(num3, num4) > num4) re = num3;
            //else if (Math.Max(num3, num4) < num4) re = num4;
            //return re;
            return new int[] { num1, num2, num3, num4 }.Max();

        }
        #endregion

        public static Bitmap SetBitmapTransparentDesktop(Control control)
        {
            Bitmap aBmp = null;
            IntPtr screenDC = HeCopUI_Framework.Win32.User32.GetDC(IntPtr.Zero);
            IntPtr memDC = HeCopUI_Framework.Win32.Gdi32.CreateCompatibleDC(screenDC);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;
            try
            {
                hBitmap = aBmp.GetHbitmap(Color.FromArgb(0));
                oldBitmap = HeCopUI_Framework.Win32.Gdi32.SelectObject(memDC, hBitmap);

                Size size = new
                     Size(aBmp.Width, aBmp.Height);

                Point pointSource = new
                    Point(0, 0);

                Point topPos = new
                    Point(control.Left, control.Top);

                HeCopUI_Framework.Win32.Struct.BLENDFUNCTION blend = new HeCopUI_Framework.Win32.Struct.BLENDFUNCTION();
                blend.BlendOp = (byte)HeCopUI_Framework.Win32.Bitmap.Enums.AlphaBlend.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = 255;
                blend.AlphaFormat = (byte)HeCopUI_Framework.Win32.Bitmap.Enums.AlphaBlend.AC_SRC_ALPHA;
                HeCopUI_Framework.Win32.User32.UpdateLayeredWindow(control.Handle, screenDC, ref topPos, ref size, memDC, ref pointSource, 0, ref blend, (int)HeCopUI_Framework.Win32.Enums.UpdateLayeredWindows.ULW_ALPHA);
            }
            catch
            {
            }
            finally
            {
                HeCopUI_Framework.Win32.User32.ReleaseDC(IntPtr.Zero, screenDC);
                if (hBitmap != IntPtr.Zero)
                {
                    HeCopUI_Framework.Win32.Gdi32.SelectObject(memDC, oldBitmap);
                    HeCopUI_Framework.Win32.Gdi32.DeleteObject(hBitmap);
                }
                HeCopUI_Framework.Win32.Gdi32.DeleteDC(memDC);
            }
            return aBmp;
        }

        #region Effect Control

        public static ControlStyles SetControlStyles()
        {
            ControlStyles CS =
                     ControlStyles.OptimizedDoubleBuffer| ControlStyles.SupportsTransparentBackColor| ControlStyles.UserPaint| ControlStyles.AllPaintingInWmPaint|
                     ControlStyles.ResizeRedraw;
            return CS;
        }


        public static void MakeTransparent(Control control, Graphics g)
        {
            Control parent = control.Parent;
            if (parent != null)
            {
                Rectangle rectangle = control.Bounds;
                Control.ControlCollection controls = parent.Controls;
                int index = controls.IndexOf(control);
                Bitmap bitmap = null;
                for (int i = controls.Count - 1; i > index; i--)
                {
                    Control control3 = controls[i];
                    if (control3.Bounds.IntersectsWith(rectangle))
                    {
                        if (bitmap == null)
                        {
                            bitmap = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                        }
                        control3.DrawToBitmap(bitmap, control3.Bounds);
                    }
                }
                if (bitmap != null)
                {
                    g.DrawImage((Image)bitmap, control.ClientRectangle, rectangle, (GraphicsUnit)GraphicsUnit.Pixel);
                    bitmap.Dispose();
                }
            }
        }


        public static Graphics GetControlGraphicsEffect(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            return g;
        }

        public static System.Drawing.Text.TextRenderingHint SetTextRender()
        {
            return System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
        );

        public static void GetStringAlign(StringFormat stringFormat, ContentAlignment contentAlignment)
        {
            switch (contentAlignment)
            {
                case ContentAlignment.TopLeft:
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleCenter:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleRight:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomRight:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    break;
            }
        }

  
        #endregion

        #region Read .Ini File
      
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;
        public static string READINIFILE(string filePath, string Section, string Key)
        {
            StringBuilder tmp = new StringBuilder(255);
            long i = HeCopUI_Framework.Win32.Kernel32. GetPrivateProfileString(Section, Key, "", tmp, 255, filePath);
            return tmp.ToString();
        }
        public static void WRITEINIFILE(string filePath, string Section, string Key, string szData)
        {
            HeCopUI_Framework.Win32.Kernel32.WritePrivateProfileString(Section, Key, szData, filePath);
        }
        public void DeleteSection(string filePath, string Section = null)
        {
            WRITEINIFILE(filePath, Section ?? EXE, null, null);
        }

        public void DeleteKey(string filePath, string Key, string Section = null)
        {
            WRITEINIFILE(filePath, Key, null, Section ?? EXE);
        }

        public bool KeyExists(string filePath, string Key, string Section = null)
        {
            return READINIFILE(filePath, Key, Section).Length > 0;
        }
        #endregion

        #region Get Encoder File
        public static string GetMD5File(string filePath)
        {
            using (var MD5File = MD5.Create())
            {
                using (FileStream FS = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(MD5File.ComputeHash(FS)).Replace("-", "");
                }
            }
        }

        public static string GetSHA1(string filePath)
        {
            using (var MD5File = SHA1.Create())
            {
                using (FileStream FS = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(MD5File.ComputeHash(FS)).Replace("-", "");
                }
            }
        }

        #endregion

        #region Read .Xml File
        static string XmlText;
        public static string ReadDataXml(string filePath, string tableName, string dataName)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(filePath);
            DataTable dt = new DataTable();
            dt = dataSet.Tables[tableName];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                XmlText = dr[dataName].ToString();
                i += 1; i++;
            }
            return XmlText;
        }

        public static void WriteDataXml(string filePath, string rootElement, string table, string tableName, string tableData, string dataName, string data)
        {
            XDocument testXML = XDocument.Load(filePath);
            XElement newStudent = new XElement(table,
            new XElement(dataName, data));
            newStudent.SetAttributeValue(tableName, tableData);
            testXML.Element(rootElement).Add(newStudent);
            testXML.Save(filePath);
        }

        public static void DeleteDataXml(string filePath, string table, string dataName, string data)
        {
            XDocument testXML = XDocument.Load(filePath);
            XElement cStudent = testXML.Descendants(table).Where(c => c.Attribute(dataName).Value.Equals(data)).FirstOrDefault();
            cStudent.Remove();

            testXML.Save(filePath);

        }
        #endregion

        #region Gets bytes size 

        public static string StringSizeOfFile(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return String.Format("{0:0.##} {1}", len, sizes[order]);
        }

        public static float LongSizeOfFile(long bytes)
        {
            double len = bytes;
            int order = 0;
            while (len >= 1024)
            {
                order++;
                len = len / 1024;
            }
            return (int)len;
        }

        public string BytesToReadableValue(long number)
        {
            List<string> suffixes = new List<string>() { " B", " KB", " MB", " GB", " TB", " PB" };

            for (int i = 0; i < suffixes.Count; i++)
            {
                long temp = number / (int)Math.Pow(1024, i + 1);

                if (temp == 0)
                {
                    return (number / (int)Math.Pow(1024, i)) + suffixes[i];
                }
            }

            return number.ToString();
        }

        #endregion

        #region Process

        public static string ProcessExecutablePath(Process process)
        {
            try
            {
                return process.MainModule.FileName;
            }
            catch
            {
                string query = "SELECT ExecutablePath, ProcessID FROM Win32_Process";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                foreach (ManagementObject item in searcher.Get())
                {
                    object id = item["ProcessID"];
                    object path = item["ExecutablePath"];

                    if (path != null && id.ToString() == process.Id.ToString())
                    {
                        return path.ToString();
                    }
                }
            }

            return "";
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RM_UNIQUE_PROCESS
        {
            public int dwProcessId;
            public System.Runtime.InteropServices.ComTypes.FILETIME ProcessStartTime;
        }

        const int RmRebootReasonNone = 0;
        const int CCH_RM_MAX_APP_NAME = 255;
        const int CCH_RM_MAX_SVC_NAME = 63;

        enum RM_APP_TYPE
        {
            RmUnknownApp = 0,
            RmMainWindow = 1,
            RmOtherWindow = 2,
            RmService = 3,
            RmExplorer = 4,
            RmConsole = 5,
            RmCritical = 1000
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        struct RM_PROCESS_INFO
        {
            public RM_UNIQUE_PROCESS Process;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_APP_NAME + 1)]
            public string strAppName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_SVC_NAME + 1)]
            public string strServiceShortName;

            public RM_APP_TYPE ApplicationType;
            public uint AppStatus;
            public uint TSSessionId;
            [MarshalAs(UnmanagedType.Bool)]
            public bool bRestartable;
        }

        [DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode)]
        static extern int RmRegisterResources(uint pSessionHandle,
                                              UInt32 nFiles,
                                              string[] rgsFilenames,
                                              UInt32 nApplications,
                                              [In] RM_UNIQUE_PROCESS[] rgApplications,
                                              UInt32 nServices,
                                              string[] rgsServiceNames);

        [DllImport("rstrtmgr.dll", CharSet = CharSet.Auto)]
        static extern int RmStartSession(out uint pSessionHandle, int dwSessionFlags, string strSessionKey);

        [DllImport("rstrtmgr.dll")]
        static extern int RmEndSession(uint pSessionHandle);

        [DllImport("rstrtmgr.dll")]
        static extern int RmGetList(uint dwSessionHandle,
                                    out uint pnProcInfoNeeded,
                                    ref uint pnProcInfo,
                                    [In, Out] RM_PROCESS_INFO[] rgAffectedApps,
                                    ref uint lpdwRebootReasons);

        /// <summary>
        /// Find out what process(es) have a lock on the specified file.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <returns>Processes locking the file</returns>
        /// <remarks>See also:
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa373661(v=vs.85).aspx
        /// http://wyupdate.googlecode.com/svn-history/r401/trunk/frmFilesInUse.cs (no copyright in code at time of viewing)
        /// 
        /// </remarks>
        static public List<Process> WhoIsLocking(string path)
        {
            uint handle;
            string key = Guid.NewGuid().ToString();
            List<Process> processes = new List<Process>();

            int res = RmStartSession(out handle, 0, key);
            if (res != 0) throw new Exception("Could not begin restart session.  Unable to determine file locker.");

            try
            {
                const int ERROR_MORE_DATA = 234;
                uint pnProcInfoNeeded = 0,
                     pnProcInfo = 0,
                     lpdwRebootReasons = RmRebootReasonNone;

                string[] resources = new string[] { path }; // Just checking on one resource.

                res = RmRegisterResources(handle, (uint)resources.Length, resources, 0, null, 0, null);

                if (res != 0) throw new Exception("Could not register resource.");

                //Note: there's a race condition here -- the first call to RmGetList() returns
                //      the total number of process. However, when we call RmGetList() again to get
                //      the actual processes this number may have increased.
                res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, null, ref lpdwRebootReasons);

                if (res == ERROR_MORE_DATA)
                {
                    // Create an array to store the process results
                    RM_PROCESS_INFO[] processInfo = new RM_PROCESS_INFO[pnProcInfoNeeded];
                    pnProcInfo = pnProcInfoNeeded;

                    // Get the list
                    res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, processInfo, ref lpdwRebootReasons);
                    if (res == 0)
                    {
                        processes = new List<Process>((int)pnProcInfo);

                        // Enumerate all of the results and add them to the 
                        // list to be returned
                        for (int i = 0; i < pnProcInfo; i++)
                        {
                            try
                            {
                                processes.Add(Process.GetProcessById(processInfo[i].Process.dwProcessId));
                            }
                            // catch the error -- in case the process is no longer running
                            catch (ArgumentException) { }
                        }
                    }
                    else throw new Exception("Could not list processes locking resource.");
                }
                else if (res != 0) throw new Exception("Could not list processes locking resource. Failed to get size of result.");
            }
            finally
            {
                RmEndSession(handle);
            }

            return processes;
        }

        public static void KillProcessesAssociatedToFile(string file)
        {
            GetProcessesAssociatedToFile(file).ForEach(x =>
            {
                x.Kill();
                x.WaitForExit(10000);
            });
        }

        public static List<Process> GetProcessesAssociatedToFile(string file)
        {
            return Process.GetProcesses()
                .Where(x => !x.HasExited
                    && x.Modules.Cast<ProcessModule>().ToList()
                        .Exists(y => y.FileName.ToLowerInvariant() == file.ToLowerInvariant())
                    ).ToList();
        }

        public static List<Process> GetProcessesLockingFile(string path)
        {
            uint handle;
            string key = Guid.NewGuid().ToString();
            int res = RmStartSession(out handle, 0, key);

            if (res != 0) throw new Exception("Could not begin restart session.  Unable to determine file locker.");

            try
            {
                const int MORE_DATA = 234;
                uint pnProcInfoNeeded, pnProcInfo = 0, lpdwRebootReasons = RmRebootReasonNone;

                string[] resources = { path }; // Just checking on one resource.

                res = RmRegisterResources(handle, (uint)resources.Length, resources, 0, null, 0, null);

                if (res != 0) throw new Exception("Could not register resource.");

                //Note: there's a race condition here -- the first call to RmGetList() returns
                //      the total number of process. However, when we call RmGetList() again to get
                //      the actual processes this number may have increased.
                res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, null, ref lpdwRebootReasons);

                if (res == MORE_DATA)
                {
                    return EnumerateProcesses(pnProcInfoNeeded, handle, lpdwRebootReasons);
                }
                else if (res != 0) throw new Exception("Could not list processes locking resource. Failed to get size of result.");
            }
            finally
            {
                RmEndSession(handle);
            }

            return new List<Process>();
        }


        private static List<Process> EnumerateProcesses(uint pnProcInfoNeeded, uint handle, uint lpdwRebootReasons)
        {
            var processes = new List<Process>(10);
            // Create an array to store the process results
            var processInfo = new RM_PROCESS_INFO[pnProcInfoNeeded];
            var pnProcInfo = pnProcInfoNeeded;

            // Get the list
            var res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, processInfo, ref lpdwRebootReasons);

            if (res != 0) throw new Exception("Could not list processes locking resource.");
            for (int i = 0; i < pnProcInfo; i++)
            {
                try
                {
                    processes.Add(Process.GetProcessById(processInfo[i].Process.dwProcessId));
                }
                catch (ArgumentException) { } // catch the error -- in case the process is no longer running
            }
            return processes;
        }

        public static Process GetProcessesStarted()
        {
            ManagementEventWatcher startWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            Process sd = null;
            startWatch.EventArrived += (s, e) =>
            {
                foreach (Process pro in Process.GetProcessesByName(e.NewEvent.Properties["ProcessName"].Value.ToString()))
                    sd = pro;
            };
            startWatch.Start();
            return sd;
        }

        public static Process GetProcessesStopped()
        {
            ManagementEventWatcher stopWatch = new ManagementEventWatcher(
             new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
            Process sd = null;
            stopWatch.EventArrived += (s, e) =>
            {
                foreach (Process pro in Process.GetProcessesByName(e.NewEvent.Properties["ProcessName"].Value.ToString()))
                    sd = pro;
            };
            stopWatch.Start();
            return sd;
        }
        #endregion

    }

}
