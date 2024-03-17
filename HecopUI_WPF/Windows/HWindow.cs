using HecopUI_WPF.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HecopUI_WPF.Windows
{
    public partial class HWindow:HWindowBase
    {
        static HWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HWindow), new FrameworkPropertyMetadata(typeof(HWindow)));
        }

       
    }
}
