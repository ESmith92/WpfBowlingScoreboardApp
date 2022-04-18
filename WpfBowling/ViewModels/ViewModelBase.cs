using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfBowling.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged//, IInputElement
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public event KeyEventHandler KeyUp;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //protected void OnKeyUp(string akey)
        //{
        //    KeyUp?.Invoke(Keyboard.KeyUpEvent, new KeyEventArgs(akey));
        //}
    }
}
