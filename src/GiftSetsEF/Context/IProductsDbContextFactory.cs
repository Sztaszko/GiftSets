namespace GiftSetsEF.Context;

public interface IProductsDbContextFactory
{
    public ProductsDbContext Create();
}
