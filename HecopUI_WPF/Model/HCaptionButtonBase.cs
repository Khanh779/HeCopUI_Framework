using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HecopUI_WPF.Model
{
    [ToolboxItem(false)]
    public partial class HCaptionButtonBase: Button
    {
        static HCaptionButtonBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HCaptionButtonBase), new FrameworkPropertyMetadata(typeof(HCaptionButtonBase)));
        }
    }
}
