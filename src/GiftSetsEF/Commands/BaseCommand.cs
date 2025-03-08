using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftSetsEF.Context;

namespace GiftSetsEF.Commands;

public class BaseCommand
{
    protected readonly IProductsDbContextFactory _dbContextFactory;

    public BaseCommand(IProductsDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
}
