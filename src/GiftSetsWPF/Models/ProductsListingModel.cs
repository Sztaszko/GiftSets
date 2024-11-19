using GiftSets.Domain.Models;
using GiftSetsWPF.Core;
using GiftSetsWPF.Services;
using System.Collections.ObjectModel;

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
        }

        public async Task InitializeAsync()
        {
            _productsListingItems = await LoadProducts();
        }

        private async Task<IEnumerable<ProductsListingItemModel>?> LoadProducts()
        {
            var dbProducts = await _productsDataProviderService.GetAllProducts();

            return DbProductsToItemModel(dbProducts);
        }

        private static IEnumerable<ProductsListingItemModel>? DbProductsToItemModel(IEnumerable<Product> dbProducts)
        {
            return dbProducts.Select(x => new ProductsListingItemModel() { 
                ProductName = x.Name,
            });
        }
    }
}
