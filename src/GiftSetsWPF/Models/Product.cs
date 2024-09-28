using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftSetsWPF.Models
{
    public class Product
    {

        public string Name { get; }
        public string Vendor { get; }
        public string Price { get; }
        public Product(string name, string vendor, string price)
        {
            Name = name;
            Vendor = vendor;
            Price = price;
        }
    }
}
