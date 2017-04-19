namespace Homemade.Models.BindingModels
{
    public class ProductBM
    {
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public byte[] Image { get; set; }
    }
}
