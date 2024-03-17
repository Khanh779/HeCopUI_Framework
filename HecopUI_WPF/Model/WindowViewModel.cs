using HecopUI_WPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
//< Window.DataContext >
//    < local:WindowViewModel />
//</ Window.DataContext >

namespace HecopUI_WPF.Model
{
    public partial class WindowViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand MaximizeCommand { get; set; }
        public ICommand MinimizeCommand {    get; set; }
        public ICommand CloseCommand { get; set; }

        public WindowViewModel()
        {
            MaximizeCommand = new RelayCommand(Maximize);
            MinimizeCommand = new RelayCommand(Minimize);
            CloseCommand = new RelayCommand(Close);
        }

        private void Maximize()
        {
            // Thực thi hành động khi nút Maximize được nhấn
            // Ví dụ:
            // WindowState = WindowState.Maximized;
        }

        private void Minimize()
        {
            // Thực thi hành động khi nút Minimize được nhấn
            // Ví dụ:
           
        }

        private void Close()
        {
         
        }

     
    }

}
