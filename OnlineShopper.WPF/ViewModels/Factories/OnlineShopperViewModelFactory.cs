using OnlineShopper.WPF.State.Navigators;
using OnlineShopper.WPF.ViewModels;
using System;

namespace OnlineShopper.WPF.ViewModels.Factories
{
    internal class OnlineShopperViewModelFactory : IOnlineShopperViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<ProductsViewModel> _createProductsViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<ProfileViewModel> _createProfileViewModel;
        // private readonly CreateViewModel<SellViewModel> _createSellViewModel;

        public OnlineShopperViewModelFactory(
            CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<ProductsViewModel> createProductViewModel,
            CreateViewModel<LoginViewModel> createLoginViewModel,
            CreateViewModel<ProfileViewModel> createProfileViewModel
        // CreateViewModel<SellViewModel> createSellViewModel
        )
        {
            _createHomeViewModel = createHomeViewModel;
            _createProductsViewModel = createProductViewModel;
            _createLoginViewModel = createLoginViewModel;
            _createProfileViewModel = createProfileViewModel;
            // _createSellViewModel = createSellViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Products:
                    return _createProductsViewModel();
                case ViewType.Profile:
                    return _createProfileViewModel();
                //case ViewType.Sell:
                //     return _createSellViewModel();
                default:
                    throw new ArgumentException(
                        "The ViewType does not have a ViewModel.",
                        "viewType"
                    );
            }
        }
    }
}
