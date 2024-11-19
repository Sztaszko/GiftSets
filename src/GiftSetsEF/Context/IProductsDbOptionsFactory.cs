using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsEF.Context;

public interface IProductsDbOptionsFactory
{
    public DbContextOptions GetOptions();
}
