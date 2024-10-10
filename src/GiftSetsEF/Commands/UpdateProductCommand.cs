using GiftSets.Domain.Commands;
using GiftSets.Domain.Models;
using GiftSetsEF.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsEF.Commands;

public class UpdateProductCommand : BaseCommand, IUpdateProductCommand
{
    public UpdateProductCommand(ProductsDbContextFactory dbContextFactory) : base(dbContextFactory)
    {
    }

    public async Task Execute(Product product)
    {
        using (var dbContext = _dbContextFactory.Create())
        {
            var productDto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Vendor = product.Vendor,
                Price = product.Price,
            };

            dbContext.Products.Update(productDto);
            await dbContext.SaveChangesAsync();
        }
    }
}
