using GiftSetsWPF.Core;
using GiftSetsWPF.Models;
using GiftSetsWPF.Services;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Input;

namespace GiftSetsWPF.ViewModels
{
    public class MainProductsViewModel : ViewModel
    {
        private readonly IProductsDataProviderService _productsDataProviderService;

        public ICommand AddProductCommand { get; }

        public ProductsListingModel ProductsListing { get; }

        public ProductDetailsViewModel ProductDetails { get; }
        
        public MainProductsViewModel(IProductsDataProviderService productsDataProviderService)
        {
            _productsDataProviderService = productsDataProviderService ?? throw new ArgumentNullException(nameof(productsDataProviderService));

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

    }
}
