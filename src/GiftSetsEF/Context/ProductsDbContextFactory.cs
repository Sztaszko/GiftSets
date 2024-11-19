using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsEF.Context;

public class ProductsDbContextFactory : IProductsDbContextFactory
{
    private readonly IProductsDbOptionsFactory _optionsFactory;
    public DbContextOptions? Options;

    public ProductsDbContextFactory(IProductsDbOptionsFactory optionsFactory)
    {
        _optionsFactory = optionsFactory;
    }

    public ProductsDbContext Create()
    {
        return new ProductsDbContext(_optionsFactory.GetOptions());
    }
}
