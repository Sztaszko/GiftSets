using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GiftSetsEF.Context;

public class ProductsDbOptionsFactory : IProductsDbOptionsFactory
{
    private readonly string _connectionString;

    public ProductsDbOptionsFactory(IOptions<ProductsDbOptions> dbOptions)
    {
        _connectionString = dbOptions.Value.ConnectionString
            ?? throw new ArgumentNullException(nameof(dbOptions.Value.ConnectionString), "Connection string is missing.");
    }

    public DbContextOptions GetOptions()
    {
        return new DbContextOptionsBuilder()
            .UseSqlServer(_connectionString)
            .Options;
    }
}
