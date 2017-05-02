﻿namespace Homemade.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductBM
    {
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Invalid product name. Name must be between 2 and 80 symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Range(0, 50000, ErrorMessage = "Price cannot be negative or more than 50000")]
        public decimal Price { get; set; }

        [Range(0, 10000, ErrorMessage = "Quantity cannot be negative or more than 10000")]
        public int Quantity { get; set; }

        public byte[] Image { get; set; }
    }
}
