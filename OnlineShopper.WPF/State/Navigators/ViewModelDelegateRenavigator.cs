using OnlineShopper.WPF.State.Navigators;
using OnlineShopper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopper.WPF.State.Navigators
{
    internal class ViewModelDelegateRenavigator<TViewModel> : IRenavigator
        where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly CreateViewModel<TViewModel> _createViewModel;

        public ViewModelDelegateRenavigator(
            INavigator navigator,
            CreateViewModel<TViewModel> createViewModel
        )
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public void Renavigate()
        {
            _navigator.Current = _createViewModel();
        }
    }
}
