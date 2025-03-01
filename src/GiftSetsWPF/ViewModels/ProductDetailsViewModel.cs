using GiftSets.Domain.Models;
using GiftSetsWPF.Core;
using GiftSetsWPF.Models;
using GiftSetsWPF.Services;

namespace GiftSetsWPF.ViewModels;

public class ProductDetailsViewModel : ViewModel
{
    private readonly IProductsDataProviderService _productsDataProviderService;
    private int _productId;
    public int ProductId 
    { 
        get => _productId; 
        set
        {
            if (_productId != value)
            {
                _productId = value;
                onPropertyChanged(nameof(ProductId));
                LoadProductDetails(ProductId);
            }
        }
    }
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

    public ProductDetailsViewModel(IProductsDataProviderService productsDataProviderService)
    {
        _productsDataProviderService = productsDataProviderService ?? throw new ArgumentNullException(nameof(productsDataProviderService));

        _item = new(null, null, null);
    }

    private void LoadProductDetails(int productId)
    {
        if (productId == -1)
        {
            return;
        }
        else
        {
            TryLoadProduct(productId);
        }
    }

    private async void TryLoadProduct(int productId)
    {
        try
        {
            await LoadProduct(productId);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Failed to load product with id={id} from database. {ex}", productId, ex);
        }
    }

    private async Task LoadProduct(int productId)
    {
        var productDetails = await _productsDataProviderService.GetProduct(productId);
        Item = DbProductToDetailsModel(productDetails);
    }

    private ProductDetailsModel DbProductToDetailsModel(Product product)
    {
        return new ProductDetailsModel
        {
            Price = product.Price.ToString(),
            ProductName = product.Name,
            Vendor = product.Vendor
        };
    }
}
