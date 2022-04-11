using System;
using System.ComponentModel;
using System.Windows.Input;
using OnlineShopper.WPF.Commands;
using OnlineShopper.WPF.Models;
using OnlineShopper.WPF.ViewModels;

namespace OnlineShopper.WPF.State.Navigators
{
    internal class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _current;

        public ViewModelBase Current
        {
            get { return _current; }
            set
            {
                _current?.Dispose();

                _current = value;
                StateChanged?.Invoke();
            }
        }
        public event Action StateChanged;
    }
}
