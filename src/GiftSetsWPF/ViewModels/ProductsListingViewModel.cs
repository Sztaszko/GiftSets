using GiftSets.Domain.Models;
using GiftSetsWPF.Core;
using GiftSetsWPF.Models;
using GiftSetsWPF.Services;

namespace GiftSetsWPF.ViewModels
{
    public class ProductsListingViewModel : ViewModel
    {
        private readonly IProductsDataProviderService _productsDataProviderService;
        private int _selectedProductID;
        private ProductsListingItemModel _selectedProduct;

        public ProductsListingItemModel SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    onPropertyChanged(nameof(SelectedProduct));
                    SelectedProductChanged(_selectedProduct);
                }
            }
        }

        public int SelectedProductID => SelectedProduct?.Id ?? -1;

        private IEnumerable<ProductsListingItemModel>? _productsListingItems;
        public IEnumerable<ProductsListingItemModel>? Items
        {
            get => _productsListingItems;
            set
            {
                _productsListingItems = value;
                onPropertyChanged();
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                onPropertyChanged();
            }
        }

        public ProductsListingViewModel(IProductsDataProviderService productsDataProviderService)
        {
            _productsDataProviderService = productsDataProviderService ?? throw new ArgumentNullException(nameof(productsDataProviderService));

            _selectedProductID = -1;
            _selectedProduct = new();
            LoadProductsAsync();
        }

        private async void LoadProductsAsync()
        {
            _isLoading = true;
            try
            {
                var dbProducts = await Task.Run(_productsDataProviderService.GetAllProducts);
                Items = DbProductsToItemModel(dbProducts);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Failed to load products from database. {ex}", ex);
            }
            finally
            {
                _isLoading = false;
            }

        }

        public void RefreshListing()
        {
            LoadProductsAsync();
        }

        private static IEnumerable<ProductsListingItemModel>? DbProductsToItemModel(IEnumerable<Product> dbProducts)
        {
            return dbProducts.Select(x => new ProductsListingItemModel()
            {
                ProductName = x.Name,
                Id = x.Id,
            });
        }


        public void SelectedProductChanged(ProductsListingItemModel selectedProduct)
        {
            //SelectedProductID = ((ProductsListingItemModel) sender).Id;
            Console.WriteLine($"Selected Product Changed: {selectedProduct?.ProductName}");
        }
    }
}
