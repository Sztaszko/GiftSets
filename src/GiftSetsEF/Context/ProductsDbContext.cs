using GiftSetsEF.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GiftSetsEF.Context;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ProductDto> Products { get; set; }
}
