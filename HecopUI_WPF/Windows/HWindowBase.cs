using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HecopUI_WPF.Windows
{
    public partial class HWindowBase:Window
    {

        public HWindowBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HWindowBase), new FrameworkPropertyMetadata(typeof(HWindowBase)));
        }
      

        internal static readonly DependencyProperty CaptionHeightProperty =
         DependencyProperty.Register("CaptionHeight", typeof(double), typeof(HWindowBase), new FrameworkPropertyMetadata((double)30));

        public static readonly DependencyProperty CaptionBrushProperty =
       DependencyProperty.Register("CaptionBrush", typeof(Brush), typeof(HWindowBase), new FrameworkPropertyMetadata(Brushes.DodgerBlue));

        public Brush CaptionBrush
        {
            get
            {
                return (Brush)GetValue(CaptionBrushProperty);
            }
            set { SetValue(CaptionBrushProperty, value); }
        }

        public static readonly DependencyProperty CaptionForeBrushProperty =
     DependencyProperty.Register("CaptionForeBrush", typeof(Brush), typeof(HWindowBase), new FrameworkPropertyMetadata(Brushes.White));

        public Brush CaptionForeBrush
        {
            get
            {
                return (Brush)GetValue(CaptionForeBrushProperty);
            }
            set { SetValue(CaptionForeBrushProperty, value); }
        }

        #region Internal Property
        internal ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }

        internal static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(HWindowBase), new PropertyMetadata(new CloseCommand()));

        internal ICommand MinCommand
        {
            get { return (ICommand)GetValue(MinCommandProperty); }
            set { SetValue(MinCommandProperty, value); }
        }

        internal static readonly DependencyProperty MinCommandProperty =
            DependencyProperty.Register("MinCommand", typeof(ICommand), typeof(HWindowBase), new PropertyMetadata(new MinCommand()));

        internal ICommand MaxCommand
        {
            get { return (ICommand)GetValue(MaxCommandProperty); }
            set { SetValue(MaxCommandProperty, value); }
        }

        internal static readonly DependencyProperty MaxCommandProperty =
            DependencyProperty.Register("MaxCommand", typeof(ICommand), typeof(HWindowBase), new PropertyMetadata(new MaxCommand()));

        #endregion

        #region Calling Methods
        public void ForceClose()
        {

            Close();
        }
        #endregion
    }

    #region Commands
    internal class CloseCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var window = (parameter as HWindowBase);
            window.ForceClose();
        }
    }
    internal class MaxCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var window = (parameter as HWindowBase);
            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Normal;
            }
            else
            {
                SystemCommands.MaximizeWindow(window);

            }
        }
    }
    internal class MinCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            (parameter as HWindowBase).WindowState = WindowState.Minimized;
        }
    }
    #endregion

}
