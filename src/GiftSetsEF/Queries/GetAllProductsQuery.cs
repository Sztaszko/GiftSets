using GiftSets.Domain.Models;
using GiftSets.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace GiftSetsEF.Queries;

public class GetAllProductsQuery : IGetAllProductsQuery
{
    private readonly ProductsDbContextFactory _dbContextFactory;

    public GetAllProductsQuery(ProductsDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<Product>> Execute()
    {
        using (var dbContext = _dbContextFactory.Create())
        {
            var productsDtos = await dbContext.Products.ToListAsync();

            return productsDtos.Select(x => new Product(x.Id, x.Name, x.Vendor, x.Price));
        }
    }
}
