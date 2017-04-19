namespace Homemade.Models.EntityModels
{
    using System.Collections.Generic;

    public class Subcategory
    {
        public Subcategory()
        {
            this.Articles = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Articles { get; set; }
    }
}
