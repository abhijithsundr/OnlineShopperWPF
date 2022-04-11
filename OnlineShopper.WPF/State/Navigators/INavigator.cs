using System.Windows.Input;
using OnlineShopper.WPF.ViewModels;

namespace OnlineShopper.WPF.State.Navigators
{
    public enum ViewType
    {
        Home,
        Products
    }

    internal interface INavigator
    {
        ViewModelBase Current { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
