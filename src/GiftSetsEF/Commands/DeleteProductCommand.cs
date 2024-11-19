using GiftSets.Domain.Commands;
using GiftSetsEF.Context;
using GiftSetsEF.DTOs;

namespace GiftSetsEF.Commands;

public class DeleteProductCommand : BaseCommand, IDeleteProductCommand
{
    public DeleteProductCommand(ProductsDbContextFactory dbContextFactory) : base(dbContextFactory)
    {
    }

    public async Task Execute(int id)
    {
        using (var dbContext = _dbContextFactory.Create())
        {
            var productDtoToDelete = new ProductDto() { ProductID = id };

            dbContext.Products.Remove(productDtoToDelete);
            await dbContext.SaveChangesAsync();
        }
    }
}
