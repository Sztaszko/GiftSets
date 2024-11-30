using GiftSets.Domain.Models;
using GiftSetsWPF.Core;
using GiftSetsWPF.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GiftSetsWPF.Models
{
    public class ProductsListingModel : ViewModel
    {
        private readonly IProductsDataProviderService _productsDataProviderService;
        private IEnumerable<ProductsListingItemModel>? _productsListingItems;
        private int _selectedProductID;

        public int SelectedProductID
        {
            get => _selectedProductID;
            set
            {
                _selectedProductID = value;
                onPropertyChanged();
            }
        }

        public IEnumerable<ProductsListingItemModel>? Items 
        { 
            get => _productsListingItems;
            set
            {
                _productsListingItems = value;
                onPropertyChanged();
            }
        }

        public ProductsListingModel(IProductsDataProviderService productsDataProviderService)
        {
            _productsDataProviderService = productsDataProviderService ?? throw new ArgumentNullException(nameof(productsDataProviderService));
            LoadProductsAsync();
        }

        private async void LoadProductsAsync()
        {
            var dbProducts = await Task.Run(_productsDataProviderService.GetAllProducts);

            Items = DbProductsToItemModel(dbProducts);
        }

        private static IEnumerable<ProductsListingItemModel>? DbProductsToItemModel(IEnumerable<Product> dbProducts)
        {
            return dbProducts.Select(x => new ProductsListingItemModel() { 
                ProductName = x.Name,
            });
        }
    }
}
