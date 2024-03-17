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
    //[TemplatePart(Name = "Area", Type = typeof(StackPanel))] 
    public partial class HTitleButtonWPF: HButtonBase
    {
        static HTitleButtonWPF()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HTitleButtonWPF), new FrameworkPropertyMetadata(typeof(HTitleButtonWPF)));
            
        }

        public static readonly DependencyProperty OverSubForegroundProperty =
           DependencyProperty.Register("OverSubForeground", typeof(Brush), typeof(HButtonBase), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.LightGray)));

        public static readonly DependencyProperty SubForegroundProperty =
        DependencyProperty.Register("SubForeground", typeof(Brush), typeof(HButtonBase), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Gray)));

        public static readonly DependencyProperty PressedSubForegroundProperty =
            DependencyProperty.Register("PressedSubForeground", typeof(Brush), typeof(HButtonBase), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.DimGray)));

        public static readonly DependencyProperty ImagePathProperty =
       DependencyProperty.Register("ImagePath", typeof(ImageSource), typeof(HTitleButtonWPF), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty ImageWidthProperty =
DependencyProperty.Register("ImageWidth", typeof(double), typeof(HTitleButtonWPF), new FrameworkPropertyMetadata((double)(60)));

        public static readonly DependencyProperty ImageHeightProperty =
DependencyProperty.Register("ImageHeight", typeof(double), typeof(HTitleButtonWPF), new FrameworkPropertyMetadata((double)(60)));

        public static readonly DependencyProperty OrientationProperty =
DependencyProperty.Register("Orientation", typeof(Orientation), typeof(HTitleButtonWPF), new FrameworkPropertyMetadata(Orientation.Vertical));

        public static readonly DependencyProperty SubContentProperty =
DependencyProperty.Register("SubContent", typeof(string), typeof(HTitleButtonWPF), new FrameworkPropertyMetadata((string)"Enter sub here"));

        internal static readonly DependencyProperty IminHeightProperty =
DependencyProperty.Register("IminHeight", typeof(bool), typeof(HTitleButtonWPF), new FrameworkPropertyMetadata(false));

        internal static readonly DependencyProperty IminWidthProperty =
DependencyProperty.Register("IminWidth", typeof(bool), typeof(HTitleButtonWPF), new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty ShowSubContentProperty =
DependencyProperty.Register("ShowSubContent", typeof(bool), typeof(HTitleButtonWPF), new FrameworkPropertyMetadata(true));

        public static readonly DependencyProperty ContentMarginProperty =
DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(HTitleButtonWPF), new FrameworkPropertyMetadata(new Thickness(5)));

        public static readonly DependencyProperty TextMarginProperty =
DependencyProperty.Register("TextMargin", typeof(Thickness), typeof(HTitleButtonWPF), new FrameworkPropertyMetadata(new Thickness(5)));

        
        //        public static readonly DependencyProperty TextAlignmentProperty =
        //DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(HTitleButtonWPF), new FrameworkPropertyMetadata(TextAlignment.Left));

        //        public TextAlignment TextAlignment
        //        {
        //            get { return (TextAlignment)GetValue(TextAlignmentProperty); }
        //            set { SetValue(TextAlignmentProperty, value); }
        //        }

       
        public Thickness TextMargin
        {
            get { return (Thickness)GetValue(TextMarginProperty); }
            set { SetValue(TextMarginProperty, value); }
        }

        public Thickness ContentMargin
        {
            get { return (Thickness)GetValue(ContentMarginProperty); }
            set { SetValue(ContentMarginProperty, value); }
        }

        internal bool IminHeight
        {
            get { return (bool)GetValue(IminHeightProperty); }
            set { SetValue(IminHeightProperty, value); }
        }

        internal bool IminWidth
        {
            get { return (bool)GetValue(IminWidthProperty); }
            set { SetValue(IminWidthProperty, value); }
        }


        public bool ShowSubContent
        {
            get { return (bool)GetValue(ShowSubContentProperty); }
            set { SetValue(ShowSubContentProperty, value); }
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            if(ImageHeight>=Height-5)
            {
                IminHeight = true;
            }
            else if(ImageHeight < Height-5) IminHeight = false;

            if (ImageWidth >= Width -5)
            {
                IminWidth = true;
            }
            else if (ImageWidth < Width-5) IminWidth= false;
            base.OnRenderSizeChanged(sizeInfo);
        }

        [Bindable(true)]
        [Category("Appearance")]
        public Brush SubForeground
        {
            get { return (Brush)GetValue(SubForegroundProperty); }
            set { SetValue(SubForegroundProperty, value); }
        }

        [Bindable(true)]
        [Category("Appearance")]
        public Brush OverSubForeground
        {
            get { return (Brush)GetValue(OverSubForegroundProperty); }
            set { SetValue(OverSubForegroundProperty, value); }
        }

        [Bindable(true)]
        [Category("Appearance")]
        public Brush PressedSubForeground
        {
            get { return (Brush)GetValue(PressedSubForegroundProperty); }
            set { SetValue(PressedSubForegroundProperty, value); }
        }


        [Bindable(true)]
        [Category("Common")]
        public string SubContent
        {
            get { return (string)GetValue(SubContentProperty); }
            set { SetValue(SubContentProperty, value); }
        }

        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
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

    }
}
