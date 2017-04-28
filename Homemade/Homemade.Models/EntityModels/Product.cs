﻿namespace Homemade.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Invalid product name. Name must be between 2 and 80 symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public Category Category { get; set; }

        [Required(ErrorMessage = "Producer is required")]
        public string Producer { get; set; }

        [Range(0, 50000, ErrorMessage = "Price cannot be negative or more than 50000")]
        public decimal Price { get; set; }

        [Range(0, 10000, ErrorMessage = "Quantity cannot be negative or more than 10000")]
        public int Quantity { get; set; }

        public string ImagePath { get; set; }
    }
}
