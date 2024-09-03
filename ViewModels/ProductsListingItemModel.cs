using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftSetsWPF.ViewModels
{
    public class ProductsListingItemModel : ViewBaseModel
    {
        public string ProductName { get; }

        public ICommand DeleteCommand { get; } 

        public ProductsListingItemModel(string productName)
        {
            ProductName = productName;
        }
    }
}
