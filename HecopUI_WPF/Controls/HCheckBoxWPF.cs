using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HecopUI_WPF.Controls
{
    public partial class HCheckBoxWPF:CheckBox
    {
        static HCheckBoxWPF()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HCheckBoxWPF), new FrameworkPropertyMetadata(typeof(HCheckBoxWPF)));
        }

        public static readonly DependencyProperty CheckMarkBrushProperty =
DependencyProperty.Register("CheckMarkBrush", typeof(Brush), typeof(HCheckBoxWPF), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.DodgerBlue)));

        public static readonly DependencyProperty CheckBoxBrushProperty =
DependencyProperty.Register("CheckBoxBrush", typeof(Brush), typeof(HCheckBoxWPF), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.White)));

        public static readonly DependencyProperty CornerRadiusProperty =
DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(HCheckBoxWPF), new FrameworkPropertyMetadata(new CornerRadius(2)));

        public static readonly DependencyProperty CheckBoxSizeProperty =
DependencyProperty.Register("CheckBoxSize", typeof(double), typeof(HCheckBoxWPF), new FrameworkPropertyMetadata((double)16));

        public static readonly DependencyProperty MouseOverCheckBoxBrushProperty =
DependencyProperty.Register("MouseOverCheckBoxBrush", typeof(Brush), typeof(HCheckBoxWPF), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.LightGray)));

        public static readonly DependencyProperty MousePressedCheckBoxBrushProperty =
DependencyProperty.Register("MousePressedCheckBoxBrush", typeof(Brush), typeof(HCheckBoxWPF), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.DarkGray)));

        public Brush MouseOverCheckBoxBrush
        {
            get { return (Brush)GetValue(MouseOverCheckBoxBrushProperty); }
            set
            {
                SetValue(MouseOverCheckBoxBrushProperty, value);
            }
        }

        public Brush MousePressedCheckBoxBrush
        {
            get { return (Brush)GetValue(MousePressedCheckBoxBrushProperty); }
            set
            {
                SetValue(MousePressedCheckBoxBrushProperty, value);
            }
        }

        public double CheckBoxSize
        {
            get { return (double)GetValue(CheckBoxSizeProperty); }
            set
            {
                SetValue(CheckBoxSizeProperty, value);
            }
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }

        public Brush CheckMarkBrush
        {
            get { return (Brush)GetValue(CheckMarkBrushProperty); }
            set
            {
                SetValue(CheckMarkBrushProperty, value);
            }
        }

        public Brush CheckBoxBrush
        {
            get { return (Brush)GetValue(CheckBoxBrushProperty); }
            set
            {
                SetValue(CheckBoxBrushProperty, value);
            }
        }

      
    }
}
