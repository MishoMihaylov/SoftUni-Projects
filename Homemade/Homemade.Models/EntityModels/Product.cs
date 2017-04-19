namespace Homemade.Models.EntityModels
{
    using Contracts;

    public class Product : IProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public byte[] Image { get; set; }
    }
}
