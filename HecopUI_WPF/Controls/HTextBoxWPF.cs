using HecopUI_WPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HecopUI_WPF.Controls
{
    public partial class HTextBoxWPF:TextBox
    {
        static HTextBoxWPF()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HTextBoxWPF), new FrameworkPropertyMetadata(typeof(HTextBoxWPF)));
        }


    

        public static readonly DependencyProperty MouseOverBackgroundProperty =
       DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(HTextBoxWPF), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.White)));

        public static readonly DependencyProperty FocusedBackgroundProperty =
            DependencyProperty.Register("FocusedBackground", typeof(Brush), typeof(HTextBoxWPF), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.LightGray)));

        public static readonly DependencyProperty MouseOverBorderBrushProperty =
   DependencyProperty.Register("MouseOverBorderBrush", typeof(Brush), typeof(HTextBoxWPF), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(32, 146, 238))));

        public static readonly DependencyProperty FocusedBorderBrushProperty =
            DependencyProperty.Register("FocusedBorderBrush", typeof(Brush), typeof(HTextBoxWPF), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(32, 126, 218))));

        //public static readonly DependencyProperty CornerRadiusProperty =
        //DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(HTextBoxWPF), new FrameworkPropertyMetadata(new CornerRadius(5)));

        public static readonly DependencyProperty ImagePathProperty =
    DependencyProperty.Register("ImagePath", typeof(ImageSource), typeof(HTextBoxWPF), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty ImageWidthProperty =
DependencyProperty.Register("ImageWidth", typeof(double), typeof(HTextBoxWPF), new FrameworkPropertyMetadata((double)(20)));

        public static readonly DependencyProperty ImageHeightProperty =
DependencyProperty.Register("ImageHeight", typeof(double), typeof(HTextBoxWPF), new FrameworkPropertyMetadata((double)(20)));

        public static readonly DependencyProperty WaterContentProperty =
DependencyProperty.Register("WaterContent", typeof(string), typeof(HTextBoxWPF), new FrameworkPropertyMetadata((string)"Enter text here."));

        [Bindable(true)]
        [Category("Common")]
        public string WaterContent
        {
            get { return (string)GetValue(WaterContentProperty); }
            set { SetValue(WaterContentProperty, value); }
        }

        public double ImageWidth
        {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public ImageSource ImagePath
        {
            get { return (ImageSource)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
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
        public Brush FocusedBackground
        {
            get { return (Brush)GetValue(FocusedBackgroundProperty); }
            set { SetValue(FocusedBackgroundProperty, value); }
        }

        [Bindable(true)]
        [Category("Appearance")]
        public Brush MouseOverBorderBrush
        {
            get { return (Brush)GetValue(MouseOverBorderBrushProperty); }
            set { SetValue(MouseOverBorderBrushProperty, value); }
        }


        [Bindable(true)]
        [Category("Appearance")]
        public Brush FocusedBorderBrush
        {
            get { return (Brush)GetValue(FocusedBorderBrushProperty); }
            set { SetValue(FocusedBorderBrushProperty, value); }
        }

        //[Bindable(true)]
        //[Category("Appearance")]
        //public CornerRadius CornerRadius
        //{
        //    get { return (CornerRadius)GetValue(CornerRadiusProperty); }
        //    set
        //    {
        //        SetValue(CornerRadiusProperty, value);
        //    }
        //}
    }
}
