﻿using GiftSets.Domain.Models;
using GiftSets.Domain.Queries;
using GiftSetsEF.Context;
using Microsoft.EntityFrameworkCore;

namespace GiftSetsEF.Queries;

public class GetAllProductsQuery : IGetAllProductsQuery
{
    private readonly IProductsDbContextFactory _dbContextFactory;

    public GetAllProductsQuery(IProductsDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<Product>> Execute()
    {
        using (var dbContext = _dbContextFactory.Create())
        {
            var productsDtos = dbContext.Products.ToList();

            return productsDtos.Select(x => new Product(x.ProductID, x.Name, x.Vendor, x.Price));
        }
    }
}
