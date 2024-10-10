using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsEF;

public class ProductsDbContextFactory
{
    private readonly DbContextOptions _options;

    public ProductsDbContextFactory(DbContextOptions options)
    {
        _options = options;
    }


    public ProductsDbContext Create()
    {
        return new ProductsDbContext(_options);
    }
}
