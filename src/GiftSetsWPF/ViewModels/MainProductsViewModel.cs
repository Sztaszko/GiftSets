using GiftSetsWPF.Core;
using GiftSetsWPF.Models;
using GiftSetsWPF.Services;
using System.ComponentModel.Design;
using System.Windows.Input;

namespace GiftSetsWPF.ViewModels
{
    public class MainProductsViewModel : ViewModel
    {
        private readonly IProductsDataProviderService _productsDataProviderService;

        public ICommand AddProductCommand { get; }

        public ProductsListingModel ProductsListing { get; }

        public ProductDetailsViewModel ProductDetailsModel { get; }
        

        public MainProductsViewModel(IProductsDataProviderService productsDataProviderService)
        {
            ProductsListing = new (productsDataProviderService);

            var _ = async () =>
            {
                await ProductsListing.InitializeAsync();
            };
        }
    }
}
