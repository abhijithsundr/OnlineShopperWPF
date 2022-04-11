using OnlineShopper.WPF.State.Navigators;

namespace OnlineShopper.WPF.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();
    }
}
