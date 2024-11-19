using Microsoft.EntityFrameworkCore;

namespace GiftSetsEF.Context;

public class ProductsDbOptionsFactory : IProductsDbOptionsFactory
{
    private readonly string _connectionString = "";

    public DbContextOptions GetOptions()
    {
        return new DbContextOptionsBuilder()
            .UseSqlServer(_connectionString)
            .Options;
    }
}
