namespace Homemade.Models.EntityModels
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Subcategory = new HashSet<Subcategory>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Subcategory> Subcategory { get; set; }
    }
}
