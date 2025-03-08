using GiftSetsWPF.Core;
using GiftSetsWPF.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Input;

namespace GiftSetsWPF.ViewModels
{
    public class MainProductsViewModel : ViewModel
    {
        private readonly IProductsDataProviderService _productsDataProviderService;
        private readonly INavigationService _navigationService;

        public RelayCommand AddProductCommand { get; }
        public RelayCommand DeleteProductCommand { get; }

        public ProductsListingViewModel ProductsListing { get; }

        public ProductDetailsViewModel ProductDetails { get; }
        
        public MainProductsViewModel(IProductsDataProviderService productsDataProviderService, INavigationService navService)
        {
            _productsDataProviderService = productsDataProviderService ?? throw new ArgumentNullException(nameof(productsDataProviderService));
            _navigationService = navService ?? throw new ArgumentNullException(nameof(navService));

            AddProductCommand = new RelayCommand(execute: o => { navService.NavigateTo<NewProductViewModel>(); }, canExecute: o => true);
            DeleteProductCommand = new RelayCommand(execute: o => DeleteProduct(ProductsListing?.SelectedProductID), canExecute: o => true); // todo add confirmation box and variable

            ProductsListing = new (productsDataProviderService);
            ProductDetails = new (productsDataProviderService);

            ProductsListing.PropertyChanged += OnSelectedProductChanged;
        }

        private void OnSelectedProductChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ProductsListing.SelectedProduct))
            {
                ProductDetails.ProductId = ProductsListing.SelectedProductID;
            }
        }

        private void DeleteProduct(int? productID)
        {
            if (productID is null || productID == -1)
            {
                return;
            }
            else
            {
                DeleteProduct((int)productID);
            }
        }

        private void DeleteProduct(int productID)
        {
            _productsDataProviderService.DeleteProduct(productID);
        }

    }
}
