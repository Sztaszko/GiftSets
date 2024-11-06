using GiftSets.Domain.Models;

namespace GiftSets.Domain.Queries;

public interface IGetAllProductsQuery
{
    Task<IEnumerable<Product>> Execute();
}
