namespace Homemade.Models.EntityModels
{
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;

    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        //TODO: Make it unique
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
