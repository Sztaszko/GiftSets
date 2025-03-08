using GiftSets.Domain.Models;
using GiftSetsWPF.Core;
using GiftSetsWPF.Models;
using GiftSetsWPF.Services;
using System.Windows.Input;

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

    public RelayCommand CreateProductCommand { get; }

    public RelayCommand CancelProductCreation { get; }

    // todo change for List<vendormodel>
    private List<string> _vendorsList;
    public List<string> VendorsList { get => _vendorsList; }

    public NewProductViewModel(IProductsDataProviderService productsDataProviderService, INavigationService navService)
    {
        _productsDataProviderService = productsDataProviderService ?? throw new ArgumentNullException(nameof(productsDataProviderService));

        _vendorsList = ["VendorExample1", "VendorExample2", "VendorExample3"];

        CreateProductCommand = new RelayCommand(canExecute: ItemIsCorrect, execute: CreateNewProduct);
        CancelProductCreation = new RelayCommand(execute: o => 
        { 
            ClearItem(); 
            navService.NavigateTo<MainProductsViewModel>(); 
        }, canExecute: o => true);

        ClearItem();
    }

    private bool ItemIsCorrect(object parameter)
    {
        return _item != null
            && !string.IsNullOrEmpty(_item.ProductName)
            && !string.IsNullOrEmpty(_item.Price)
            && !string.IsNullOrEmpty(_item.Vendor)
            && _vendorsList.Contains(_item.Vendor);
    }

    private void CreateNewProduct(object parameter)
    {
        var newProduct = new Product(0, _item.ProductName!, _item.Vendor!, Decimal.Parse(_item.Price!));

        AddProductToDB(newProduct);
        ClearItem();
    }
    private void AddProductToDB(Product newProduct)
    {
        _productsDataProviderService.CreateProduct(newProduct);
    }

    private void ClearItem()
    {
        _item = new ProductDetailsModel();
    }

}
