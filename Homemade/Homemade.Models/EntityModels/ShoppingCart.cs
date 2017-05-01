namespace Homemade.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.Items = new HashSet<CartProduct>();
        }

        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public HomemadeUser Owner { get; set; }

        public ICollection<CartProduct> Items { get; set; }
    }
}
