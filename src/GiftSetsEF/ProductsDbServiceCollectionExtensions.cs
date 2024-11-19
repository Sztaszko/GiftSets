using GiftSetsEF.Context;
using Microsoft.Extensions.DependencyInjection;

namespace GiftSetsEF;

public static class ProductsDbServiceCollectionExtensions
{
    public static IServiceCollection AddProductsDbServices(this IServiceCollection services)
    {
        services.AddTransient<IProductsDbContextFactory, ProductsDbContextFactory>();
        services.AddTransient<IProductsDbOptionsFactory, ProductsDbOptionsFactory>();
        return services;
    }
}
