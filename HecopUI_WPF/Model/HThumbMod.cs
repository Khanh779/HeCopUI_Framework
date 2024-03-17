using HecopUI_WPF.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace HecopUI_WPF.Model
{
 
    [DefaultEvent("DragDelta")]
    [Localizability(LocalizationCategory.NeverLocalize)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.ComponentModel.DesignTimeVisible(false)]
    public partial class HThumbMod : Thumb
    {
        static HThumbMod()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HThumbMod), new FrameworkPropertyMetadata(typeof(HThumbMod)));
            
        }

        public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(HThumbMod), new FrameworkPropertyMetadata(new CornerRadius(2)));

        [Bindable(true)]
        [Category("Appearance")]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
    }
}
