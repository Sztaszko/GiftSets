using GiftSetsWPF.Core;
using GiftSetsWPF.Services;

namespace GiftSetsWPF.ViewModels;

class MainViewModel : ViewModel
{
    private INavigationService _navigationService;

    public INavigationService Navigation
    {
        get => _navigationService;

        set
        {
            _navigationService = value;
            onPropertyChanged();
        }
    }

    public RelayCommand NavigateToMainProductsViewCommand { get; set; }
    public RelayCommand NavigateToProductDetailsCommand { get; set; }


    public MainViewModel(INavigationService navService)
    {
        Navigation = navService;

        NavigateToMainProductsViewCommand = new RelayCommand(execute:o => { Navigation.NavigateTo<MainProductsViewModel>(); }, canExecute:o => true);
        NavigateToProductDetailsCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<ProductDetailsViewModel>(); }, canExecute:o => true);

    }
}
