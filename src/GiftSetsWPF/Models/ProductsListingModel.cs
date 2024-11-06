using GiftSetsWPF.Core;
using System.Collections.ObjectModel;

namespace GiftSetsWPF.Models
{
    public class ProductsListingModel : ViewModel
    {
        private readonly ObservableCollection<ProductsListingItemModel> _productsListingItems;

        public IEnumerable<ProductsListingItemModel> Items => _productsListingItems;

        public ProductsListingModel()
        {
            _productsListingItems = [new("Example product name"), new("Example product name2")];
        }
    }
}
