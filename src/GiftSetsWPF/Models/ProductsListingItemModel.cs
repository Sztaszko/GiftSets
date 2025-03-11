using GiftSetsWPF.Core;
using System.Windows.Input;

namespace GiftSetsWPF.Models
{
    public class ProductsListingItemModel : ViewModel
    {
        public string ProductName { get; set; }

        public int? Id { get; set; }

        //public ICommand DeleteCommand { get; }

        public ProductsListingItemModel()
        {
            ProductName = "";
            Id = null;
        }

        public ProductsListingItemModel(string productName, int id)
        {
            ProductName = productName;
            Id = id;
        }
    }
}
