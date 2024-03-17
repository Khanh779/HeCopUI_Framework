using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HecopUI_WPF.Controls
{
    public partial class HTabControlWPF:TabControl
    {
        static HTabControlWPF()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HTabControlWPF), new FrameworkPropertyMetadata(typeof(HTabControlWPF)));
        }
    }
}
