using GiftSetsWPF.Stores;
using System.Collections.ObjectModel;

namespace GiftSetsWPF.ViewModels
{
    public class ProductsListingModel : ViewBaseModel
    {
        private readonly ObservableCollection<ProductsListingItemModel> _productsListingItems;
        private readonly SelectedProductStore _selectedProductStore;

        public IEnumerable<ProductsListingItemModel> ProductsListingItems => _productsListingItems;

        public ProductsListingModel(SelectedProductStore selectedProductStore)
        {
            _productsListingItems = [new("Example product name"), new("Example product name2")];
            _selectedProductStore = selectedProductStore;
        }
    }
}
