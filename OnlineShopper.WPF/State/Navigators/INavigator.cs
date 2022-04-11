using System.Windows.Input;
using RockstarTHA.WPF.ViewModels;

namespace RockstarTHA.WPF.State.Navigators
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
