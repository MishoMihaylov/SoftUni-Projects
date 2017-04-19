namespace Homemade.Models.EntityModels.Contracts
{
    public interface IProduct
    {
        int Id { get; set; }

        string Name { get; set; }

        string Manufacturer { get; set; }

        decimal Price { get; set; }

        int Quantity { get; set; }

        byte[] Image { get; set; }
    }
}
