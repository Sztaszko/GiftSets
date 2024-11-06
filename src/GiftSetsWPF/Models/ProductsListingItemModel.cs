using GiftSetsWPF.Core;
using System.Windows.Input;

namespace GiftSetsWPF.Models
{
    public class ProductsListingItemModel : ViewModel
    {
        public string ProductName { get; }

        public ICommand DeleteCommand { get; }

        public ProductsListingItemModel(string productName)
        {
            ProductName = productName;
        }
    }
}
