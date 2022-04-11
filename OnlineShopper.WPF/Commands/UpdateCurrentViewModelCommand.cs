using System;
using System.Windows.Input;
using RockstarTHA.WPF.ViewModels;
using RockstarTHA.WPF.State.Navigators;

namespace RockstarTHA.WPF.Commands
{
    /// <summary>
    /// This class is responsible for taking an INavigator and updating the ViewModel
    /// every time the tab is changed.
    /// </summary>
    internal class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.Current = new HomeViewModel();
                        break;
                    case ViewType.Products:
                        _navigator.Current = new ProductsViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
