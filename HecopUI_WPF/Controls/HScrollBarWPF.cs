using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HecopUI_WPF.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:HecopUI_WPF.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:HecopUI_WPF.Controls;assembly=HecopUI_WPF.Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:HScrollBarWPF/>
    ///
    /// </summary>
    public class HScrollBarWPF : ScrollBar
    {
        static HScrollBarWPF()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HScrollBarWPF), new FrameworkPropertyMetadata(typeof(HScrollBarWPF)));
            
        }

        public HScrollBarWPF()
        {
          
        }

        public static readonly DependencyProperty ThumbBackgroundBrushProperty =
          DependencyProperty.Register("ThumbBackgroundBrush", typeof(Brush), typeof(HScrollBarWPF), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.DodgerBlue)));

        public static readonly DependencyProperty ThumbBorderBrushProperty =
      DependencyProperty.Register("ThumbBorderBrush", typeof(Brush), typeof(HScrollBarWPF), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.DodgerBlue)));

        public static readonly DependencyProperty ThumbBorderThicknessProperty =
   DependencyProperty.Register("ThumbBorderThickness", typeof(Thickness), typeof(HScrollBarWPF), new FrameworkPropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty CornerRadiusProperty =
 DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(HScrollBarWPF), new FrameworkPropertyMetadata(new CornerRadius(2)));

        public static readonly DependencyProperty ThumbCornerRadiusProperty =
 DependencyProperty.Register("ThumbCornerRadius", typeof(CornerRadius), typeof(HScrollBarWPF), new FrameworkPropertyMetadata(new CornerRadius(2)));

        [Bindable(true)]
        [Category("Appearance")]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        [Bindable(true)]
        [Category("Appearance")]
        public CornerRadius ThumbCornerRadius
        {
            get { return (CornerRadius)GetValue(ThumbCornerRadiusProperty); }
            set { SetValue(ThumbCornerRadiusProperty, value); }
        }

        [Bindable(true)]
        [Category("Appearance")]
        public Thickness ThumbBorderThickness
        {
            get { return (Thickness)GetValue(ThumbBorderThicknessProperty); }
            set { SetValue(ThumbBorderThicknessProperty, value); }
        }

        [Bindable(true)]
        [Category("Appearance")]
        public Brush ThumbBackgroundBrush
        {
            get { return (Brush)GetValue(ThumbBackgroundBrushProperty); }
            set { SetValue(ThumbBackgroundBrushProperty, value); }
        }

        [Bindable(true)]
        [Category("Appearance")]
        public Brush ThumbBorderBrush
        {
            get { return (Brush)GetValue(ThumbBorderBrushProperty); }
            set { SetValue(ThumbBorderBrushProperty, value); }
        }
    }
}
