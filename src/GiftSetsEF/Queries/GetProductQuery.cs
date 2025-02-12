using GiftSets.Domain.Models;
using GiftSets.Domain.Queries;
using GiftSetsEF.Context;

namespace GiftSetsEF.Queries;

public class GetProductQuery : IGetProductQuery
{
    private readonly IProductsDbContextFactory _dbContextFactory;

    public GetProductQuery(IProductsDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<Product> Execute(int productId)
    {
        using (var dbContext = _dbContextFactory.Create())
        {
            var productDto = dbContext.Products.Where(x => x.ProductID == productId).ToList();

            return productDto.Select(x => new Product(x.ProductID, x.Name, x.Vendor, x.Price)).First();
        }
    }
}
