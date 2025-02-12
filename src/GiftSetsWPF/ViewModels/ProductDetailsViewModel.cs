using GiftSetsWPF.Core;
using GiftSetsWPF.Models;
using GiftSetsWPF.Services;

namespace GiftSetsWPF.ViewModels
{
    public class ProductDetailsViewModel : ViewModel
    {
        private readonly IProductsDataProviderService _productsDataProviderService;
        private int _productId;
        public int ProductId 
        { 
            get => _productId; 
            set
            {
                if (_productId != value)
                {
                    _productId = value;
                    onPropertyChanged(nameof(ProductId));
                    LoadProductDetails(ProductId);
                }
            } 
        }
        private ProductDetailsModel _item;
        public ProductDetailsModel Item { 
            get => _item; 
            set
            {
                if (_item != value)
                {
                    _item = value;
                    onPropertyChanged(nameof(Item));
                }
            }
        }

        public ProductDetailsViewModel(IProductsDataProviderService productsDataProviderService)
        {
            _productsDataProviderService = productsDataProviderService ?? throw new ArgumentNullException(nameof(productsDataProviderService));

            _item = new(null, null, null);
        }

        private async void LoadProductDetails(int productId)
        {
            //Item = new ProductDetailsModel(
            //    productName : "Example product name",
            //    vendor: "Example vendor name",
            //    price:  "Example price");
            throw new NotImplementedException();
        }
    }
}
