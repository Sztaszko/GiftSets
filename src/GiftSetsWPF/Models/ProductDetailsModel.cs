using GiftSetsWPF.Core;

namespace GiftSetsWPF.Models;

public class ProductDetailsModel : ObservableObject 
{
    private string? _productName;
    private string? _vendor;
    private string? _price;

    public string? ProductName { 
        get => _productName; 
        set
        {
            if (_productName != value)
            {
                _productName = value;
                onPropertyChanged(nameof(ProductName));
            }
        }
    }

    public string? Vendor 
    {
        get => _vendor;
        set
        {
            if (_vendor != value)
            {
                _vendor = value;
                onPropertyChanged(nameof(Vendor));
            }
        }
    }

    public string? Price 
    {
        get => _price;
        set
        {
            if (_price != value)
            {
                _price = value;
                onPropertyChanged(nameof(Price));
            }
        }
    }

    public ProductDetailsModel()
    {
        ProductName = null;
        Vendor = null;
        Price = null;
    }

    public ProductDetailsModel(string? productName, string? vendor, string? price)
    {
        ProductName = productName;
        Vendor = vendor;
        Price = price;
    }
}
