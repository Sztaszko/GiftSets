using GiftSetsWPF.Core;
using GiftSetsWPF.Models;
using GiftSetsWPF.Services;

namespace GiftSetsWPF.ViewModels;

class NewProductViewModel : ViewModel
{ 
    IProductsDataProviderService _productsDataProviderService;

    private ProductDetailsModel _item;
    public ProductDetailsModel Item { 
        get => _item;
        set
        {
            if (_item != value)
            {
                _item = value;
                onPropertyChanged(nameof(Item));
            }
        }
    }

    // todo change for List<vendormodel>
    private List<string> _vendorsList;
    public List<string> VendorsList { get => _vendorsList; }

    public NewProductViewModel(IProductsDataProviderService productsDataProviderService)
    {
        _productsDataProviderService = productsDataProviderService ?? throw new ArgumentNullException(nameof(productsDataProviderService));

        _vendorsList = ["VendorExample1", "VendorExample2", "VendorExample3"];
    }
}
