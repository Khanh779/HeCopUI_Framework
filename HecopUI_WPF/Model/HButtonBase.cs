using HecopUI_WPF.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HecopUI_WPF.Model
{
    [Localizability(LocalizationCategory.NeverLocalize)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.ComponentModel.DesignTimeVisible(false)]
    public partial class HButtonBase : Button
    {

        //static HButtonBase()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(HButtonBase), new FrameworkPropertyMetadata(typeof(HButtonBase)));
        //}

        public static readonly DependencyProperty MouseOverBackgroundProperty =
           DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(HButtonBase), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(32, 146, 238))));

        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(HButtonBase), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(32, 126, 218))));

        public static readonly DependencyProperty OverForegroundProperty =
            DependencyProperty.Register("OverForeground", typeof(Brush), typeof(HButtonBase), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(250, 250, 250))));

        public static readonly DependencyProperty PressedForegroundProperty =
            DependencyProperty.Register("PressedForeground", typeof(Brush), typeof(HButtonBase), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(240, 240, 240))));

        public static readonly DependencyProperty CornerRadiusProperty =
           DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(HButtonBase), new FrameworkPropertyMetadata(new CornerRadius(5)));

        [Bindable(true)]
        [Category("Appearance")]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        public Brush MouseOverBackground
        {
            get { return (Brush)GetValue(MouseOverBackgroundProperty); }
            set { SetValue(MouseOverBackgroundProperty, value); }
        }


        [Bindable(true)]
        [Category("Appearance")]
        public Brush PressedBackground
        {
            get { return (Brush)GetValue(PressedBackgroundProperty); }
            set { SetValue(PressedBackgroundProperty, value); }
        }

        [Bindable(true)]
        [Category("Appearance")]
        public Brush OverForeground
        {
            get { return (Brush)GetValue(OverForegroundProperty); }
            set { SetValue(OverForegroundProperty, value); }
        }

        [Bindable(true)]
        [Category("Appearance")]
        public Brush PressedForeground
        {
            get { return (Brush)GetValue(PressedForegroundProperty); }
            set { SetValue(PressedForegroundProperty, value); }
        }

    }
}
