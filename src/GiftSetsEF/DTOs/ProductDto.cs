using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsEF.DTOs;

public class ProductDto
{
    [Key]
    public int ProductID { get; set; }

    public string Name { get; set; }
    public decimal Price { get; set; }

    public string Vendor { get; set; }

}
