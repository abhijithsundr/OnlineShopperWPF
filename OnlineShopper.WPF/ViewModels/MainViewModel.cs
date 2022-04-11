using RockstarTHA.WPF.State.Navigators;

namespace RockstarTHA.WPF.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();
    }
}
