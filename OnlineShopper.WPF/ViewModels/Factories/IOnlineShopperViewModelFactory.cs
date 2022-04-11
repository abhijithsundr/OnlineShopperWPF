using OnlineShopper.WPF.State.Navigators;
using OnlineShopper.WPF.ViewModels;

namespace OnlineShopper.WPF.ViewModels.Factories
{
    internal interface IOnlineShopperViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
