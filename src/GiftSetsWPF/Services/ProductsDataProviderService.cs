using GiftSets.Domain.Models;
using GiftSets.Domain.Queries;
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

    public ProductsDataProviderService(IProductsDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

        _getAllProductsQuery = new GetAllProductsQuery(_dbContextFactory);
        _getProductQuery = new GetProductQuery(_dbContextFactory);
    }

    public Task<IEnumerable<Product>> GetAllProducts()
    {
        return _getAllProductsQuery.Execute();
    }

    public Task<Product> GetProduct(int productId)
    {
        return _getProductQuery.Execute(productId);
    }
}
