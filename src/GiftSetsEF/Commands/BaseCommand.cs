using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsEF.Commands;

public class BaseCommand
{
    protected readonly ProductsDbContextFactory _dbContextFactory;

    public BaseCommand(ProductsDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
}
