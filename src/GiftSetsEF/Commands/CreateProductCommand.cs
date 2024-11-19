using GiftSets.Domain.Commands;
using GiftSets.Domain.Models;
using GiftSetsEF.Context;
using GiftSetsEF.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GiftSetsEF.Commands;

public class CreateProductCommand : BaseCommand, ICreateProductCommand
{
    public CreateProductCommand(ProductsDbContextFactory dbContextFactory) : base(dbContextFactory) { }

    public async Task Execute(Product product)
    {
        using (var dbContext = _dbContextFactory.Create())
        {
            var productDto = new ProductDto()
            {
                ProductID = product.Id,
                Name = product.Name,
                Vendor = product.Vendor,
                Price = product.Price,
            };

            dbContext.Products.Add(productDto);
            await dbContext.SaveChangesAsync();
        }
    }
}
