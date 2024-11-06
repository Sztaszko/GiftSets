using GiftSets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsWPF.Services;

public interface IProductsDataProviderService
{
    Task<IEnumerable<Product>> GetAllProducts();
}
