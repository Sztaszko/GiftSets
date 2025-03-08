using GiftSets.Domain.Commands;
using GiftSets.Domain.Models;
using GiftSets.Domain.Queries;
using GiftSetsEF.Commands;
using GiftSetsEF.Context;
using GiftSetsEF.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsWPF.Services;

public class ProductsDataProviderService : IProductsDataProviderService
{
    private readonly IProductsDbContextFactory _dbContextFactory;
    private readonly IGetAllProductsQuery _getAllProductsQuery;
    private readonly IGetProductQuery _getProductQuery;
    private readonly ICreateProductCommand _createProductCommand;
    private readonly IDeleteProductCommand _deleteProductCommand;

    public ProductsDataProviderService(IProductsDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

        _getAllProductsQuery = new GetAllProductsQuery(_dbContextFactory);
        _getProductQuery = new GetProductQuery(_dbContextFactory);
        _createProductCommand = new CreateProductCommand(_dbContextFactory);
        _deleteProductCommand = new DeleteProductCommand(_dbContextFactory);
    }

    public Task<IEnumerable<Product>> GetAllProducts()
    {
        return _getAllProductsQuery.Execute();
    }

    public Task<Product> GetProduct(int productId)
    {
        return _getProductQuery.Execute(productId);
    }

    public void CreateProduct(Product product)
    {
        _createProductCommand.Execute(product);
    }

    public void DeleteProduct(int productId)
    {
        _deleteProductCommand.Execute(productId);
    }
}
