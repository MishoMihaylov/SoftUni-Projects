namespace Homemade.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Invalid category name. Name must be between 2 and 80 symbols")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
