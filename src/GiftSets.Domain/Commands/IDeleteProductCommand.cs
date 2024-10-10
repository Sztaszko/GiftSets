using GiftSets.Domain.Models;

namespace GiftSets.Domain.Commands;

public interface IDeleteProductCommand
{
    Task Execute(Guid id);
}
