using GiftSets.Domain.Models;

namespace GiftSets.Domain.Queries;

public interface GetAllProductsQuery
{
    Task<IEnumerable<Product>> Execute();
}
