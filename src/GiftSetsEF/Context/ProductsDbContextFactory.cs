using Microsoft.EntityFrameworkCore;

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
