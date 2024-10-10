namespace GiftSets.Domain.Models
{
    public class Product
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Vendor { get; }
        
        public string Price { get; }
        
        public Product(Guid id, string name, string vendor, string price)
        {
            Id = id;
            Name = name;
            Vendor = vendor;
            Price = price;
        }
    }
}
