using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HeCopUI_Framework.Helper
{
    public class DPIHelper
    {
        #region Hight DPI
        [DllImport("shcore.dll")]

        public static extern int SetProcessDpiAwareness(process_dpi value);

        public enum process_dpi
        {
            Process_DPI_Unaware = 0,
            Process_System_DPI_Aware = 1,
            Process_Per_Monitor_DPI_Aware = 2
        }

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        /// <summary>
        /// Sets hight dpi for application.
        /// </summary>
        public static extern bool SetProcessDPIAware();

        #endregion
    }
}
