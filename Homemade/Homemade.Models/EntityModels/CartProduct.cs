namespace Homemade.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CartProduct
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        public ShoppingCart Cart { get; set; }

        [Key, Column(Order = 2)]
        public Product Product { get; set; }

        [Range(0, 1000, ErrorMessage = "Count cannot be negative or more than 1000")]
        public int Count { get; set; }
    }
}
