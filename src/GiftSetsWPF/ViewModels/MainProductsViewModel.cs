using GiftSetsWPF.Core;
using GiftSetsWPF.Models;
using System.Windows.Input;

namespace GiftSetsWPF.ViewModels
{
    public class MainProductsViewModel : ViewModel
    {
        public ICommand AddProductCommand { get; }

        public ProductsListingModel ProductsListing { get; }

        public ProductDetailsViewModel ProductDetailsModel { get; }
        

        public MainProductsViewModel()
        {
            ProductsListing = new ();
        }
    }
}
