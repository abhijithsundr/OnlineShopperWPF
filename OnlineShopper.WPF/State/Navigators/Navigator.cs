using System.ComponentModel;
using System.Windows.Input;
using RockstarTHA.WPF.Commands;
using RockstarTHA.WPF.Models;
using RockstarTHA.WPF.ViewModels;

namespace RockstarTHA.WPF.State.Navigators
{
    internal class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _current;

        public ViewModelBase Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged(nameof(Current));
            }
        }
        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}
