namespace GiftSets.Domain.Models
{
    public class Product
    {
        public int Id { get; }

        public string Name { get; }

        public string Vendor { get; }
        
        public decimal Price { get; }
        
        public Product(int id, string name, string vendor, decimal price)
        {
            Id = id;
            Name = name;
            Vendor = vendor;
            Price = price;
        }
    }
}
