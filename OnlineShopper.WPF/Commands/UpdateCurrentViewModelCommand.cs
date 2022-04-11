using System;
using System.Windows.Input;
using OnlineShopper.WPF.ViewModels;
using OnlineShopper.WPF.State.Navigators;
using OnlineShopper.WPF.ViewModels.Factories;

namespace OnlineShopper.WPF.Commands
{
    /// <summary>
    /// This class is responsible for taking an INavigator and updating the ViewModel
    /// every time the tab is changed.
    /// </summary>
    internal class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IOnlineShopperViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(
            INavigator navigator,
            IOnlineShopperViewModelFactory viewModelFactory
        )
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                _navigator.Current = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
