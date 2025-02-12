using GiftSets.Domain.Models;

namespace GiftSets.Domain.Queries;

public interface IGetProductQuery
{
    Task<Product> Execute(int productId);
}
