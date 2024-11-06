using GiftSets.Domain.Models;
using GiftSets.Domain.Queries;
using GiftSetsEF;
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
    private readonly string _connectionString;
    private readonly ProductsDbContextFactory _dbContextFactory;
    private readonly IGetAllProductsQuery _getAllProductsQuery;

    public ProductsDataProviderService()
    {
        // TODO move it to separate service or onStartup
        _connectionString = "";
        var options = new DbContextOptionsBuilder()
            .UseSqlServer(_connectionString)
            .Options;

        _dbContextFactory = new ProductsDbContextFactory(options);

        _getAllProductsQuery = new GetAllProductsQuery(_dbContextFactory);
    }

    public Task<IEnumerable<Product>> GetAllProducts()
    {
        return _getAllProductsQuery.Execute();
    }
}
