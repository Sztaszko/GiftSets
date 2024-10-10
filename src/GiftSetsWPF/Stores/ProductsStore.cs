using GiftSets.Domain.Commands;
using GiftSets.Domain.Models;
using GiftSets.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsWPF.Stores;

public class ProductsStore
{
    private readonly IGetAllProductsQuery _getAllProductsQuery;
    private readonly ICreateProductCommand _createProductCommand;
    private readonly IDeleteProductCommand _deleteProductCommand;
    private readonly IUpdateProductCommand _updateProductCommand;

    public event Action<Product> ProductAdded;
    public event Action<Product> ProductUpdated;

    public ProductsStore()
    {
        _getAllProductsQuery = getAllProductsQuery;
        _createProductCommand = createProductCommand;
        _deleteProductCommand = deleteProductCommand;
        _updateProductCommand = updateProductCommand;
    }

    public async Task Add(Product product)
    {
        _createProductCommand.Execute(product);

        
    }

}
