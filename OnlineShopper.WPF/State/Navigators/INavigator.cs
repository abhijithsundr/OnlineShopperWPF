using System;
using System.Windows.Input;
using OnlineShopper.WPF.ViewModels;

namespace OnlineShopper.WPF.State.Navigators
{
    public enum ViewType
    {
        Login,
        Home,
        Products,
        Profile,
        AdminPanel
    }

    internal interface INavigator
    {
        ViewModelBase Current { get; set; }
        event Action StateChanged;
    }
}
