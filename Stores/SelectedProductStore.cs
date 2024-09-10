using GiftSetsWPF.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsWPF.Stores;

public class SelectedProductStore
{
    private Product _product;

    public Product SelectedProduct
    {
        get 
        { 
            return _product; 
        }
        set 
        { 
            _product = value;
            SelectedProductChanged?.Invoke();
        }
    }

    public event Action SelectedProductChanged;

}
