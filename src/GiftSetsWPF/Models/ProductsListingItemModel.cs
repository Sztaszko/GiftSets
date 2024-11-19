using GiftSetsWPF.Core;
using System.Windows.Input;

namespace GiftSetsWPF.Models
{
    public class ProductsListingItemModel : ViewModel
    {
        public string ProductName { get; set; }

        public ICommand DeleteCommand { get; }

        public ProductsListingItemModel()
        {
            
        }

        public ProductsListingItemModel(string productName)
        {
            ProductName = productName;
        }
    }
}
