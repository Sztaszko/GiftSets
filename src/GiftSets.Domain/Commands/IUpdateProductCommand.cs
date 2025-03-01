﻿using GiftSets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSets.Domain.Commands;

public interface IUpdateProductCommand
{
    Task Execute(Product product);
}
