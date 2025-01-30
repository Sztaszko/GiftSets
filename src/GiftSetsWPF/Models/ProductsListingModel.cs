﻿using GiftSets.Domain.Models;
using GiftSetsWPF.Core;
using GiftSetsWPF.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GiftSetsWPF.Models
{
    public class ProductsListingModel : ViewModel
    {
        private readonly IProductsDataProviderService _productsDataProviderService;
        private int _selectedProductID;
        public int SelectedProductID
        {
            get => _selectedProductID;
            set
            {
                _selectedProductID = value;
                onPropertyChanged();
            }
        }

        private IEnumerable<ProductsListingItemModel>? _productsListingItems;
        public IEnumerable<ProductsListingItemModel>? Items 
        { 
            get => _productsListingItems;
            set
            {
                _productsListingItems = value;
                onPropertyChanged();
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                onPropertyChanged();
            }
        }

        public ProductsListingModel(IProductsDataProviderService productsDataProviderService)
        {
            _productsDataProviderService = productsDataProviderService ?? throw new ArgumentNullException(nameof(productsDataProviderService));
            LoadProductsAsync();
        }

        private async void LoadProductsAsync()
        {
            _isLoading = true;
            try
            {
                var dbProducts = await Task.Run(_productsDataProviderService.GetAllProducts);
                Items = DbProductsToItemModel(dbProducts);
            }
            catch (Exception ex) 
            {
                Console.Error.WriteLine("Failed to load products from database. {ex}", ex);
            }
            finally
            {
                _isLoading = false;
            }

        }

        private static IEnumerable<ProductsListingItemModel>? DbProductsToItemModel(IEnumerable<Product> dbProducts)
        {
            return dbProducts.Select(x => new ProductsListingItemModel() { 
                ProductName = x.Name,
            });
        }
    }
}
