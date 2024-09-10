﻿using GiftSetsWPF.Stores;
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

        public ProductDetailsViewModel ProductDetailsModel { get; }

        public ICommand AddProductCommand { get; }

        public MainProductsViewModel(SelectedProductStore selectedProductStore)
        {
            ProductDetailsModel = new ProductDetailsViewModel(selectedProductStore);
            ProductListingModel = new ProductsListingModel(selectedProductStore);
        }
    }
}
