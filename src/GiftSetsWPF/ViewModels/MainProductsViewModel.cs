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
        private readonly Task _initializeProductsListingTask;

        public ICommand AddProductCommand { get; }

        public ProductsListingModel ProductsListing { get; }

        public ProductDetailsViewModel ProductDetailsModel { get; }
        
        public MainProductsViewModel(IProductsDataProviderService productsDataProviderService)
        {
            _productsDataProviderService = productsDataProviderService ?? throw new ArgumentNullException(nameof(productsDataProviderService));

            ProductsListing = new (productsDataProviderService);

            _initializeProductsListingTask =  ProductsListing.InitializeAsync();
            //ProductsListing.InitializeAsync().GetAwaiter().GetResult();
        }
    }
}
