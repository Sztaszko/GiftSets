using GiftSetsWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsWPF.ViewModels
{
    public class ProductDetailsViewModel : ViewBaseModel
    {
        private readonly SelectedProductStore selectedProductStore;

        public string? ProductName => selectedProductStore.SelectedProduct.Name;
        public string? Vendor => selectedProductStore.SelectedProduct.Vendor;
        public string? Price => selectedProductStore.SelectedProduct.Price;
        
        public ProductDetailsViewModel(SelectedProductStore selectedProductStore)
        {
            this.selectedProductStore = selectedProductStore;
        }
    }
}
