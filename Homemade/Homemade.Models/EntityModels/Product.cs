namespace Homemade.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product()
        {
            this.InOrders = new HashSet<OrderProduct>();
            this.CartProducts = new HashSet<CartProduct>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Invalid product name. Name must be between 2 and 80 symbols")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        [Range(0, 50000, ErrorMessage = "Price cannot be negative or more than 50000")]
        public decimal Price { get; set; }

        public virtual ICollection<OrderProduct> InOrders { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }

        //public string ImagePath { get; set; }
    }
}
