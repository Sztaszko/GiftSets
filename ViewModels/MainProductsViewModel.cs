using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftSetsWPF.ViewModels
{
    public class MainProductsViewModel : ViewBaseModel
    {
        public ProductsListingModel ProductListingModel { get; }

        public ProductDetailsModel ProductDetailsModel { get; }

        public ICommand AddProductCommand { get; }

        public MainProductsViewModel()
        {
            ProductDetailsModel = new ProductDetailsModel();
            ProductListingModel = new ProductsListingModel();
        }
    }
}
