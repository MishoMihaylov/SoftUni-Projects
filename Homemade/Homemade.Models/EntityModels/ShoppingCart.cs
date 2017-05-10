namespace Homemade.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.Items = new HashSet<CartProduct>();
        }

        [Key]
        [ForeignKey("Owner")]
        public string Id { get; set; }

        public virtual HomemadeUser Owner { get; set; }

        public virtual ICollection<CartProduct> Items { get; set; }
    }
}
