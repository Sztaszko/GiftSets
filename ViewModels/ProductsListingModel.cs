using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsWPF.ViewModels
{
    public class ProductsListingModel : ViewBaseModel
    {
        private readonly ObservableCollection<ProductsListingItemModel> _productsListingItems;

        public IEnumerable<ProductsListingItemModel> ProductsListingItems => _productsListingItems;

        public ProductsListingModel()
        {
            _productsListingItems = new();
            _productsListingItems.Add(new("Example product name"));
            _productsListingItems.Add(new("Example product name2"));

        }
    }
}
