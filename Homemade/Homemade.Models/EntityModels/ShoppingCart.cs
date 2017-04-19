namespace Homemade.Models.EntityModels
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.SelectedItems = new HashSet<Product>();
        }

        public int Id { get; set; }

        public HomemadeUser CartOwner { get; set; }

        public ICollection<Product> SelectedItems { get; set; }
    }
}
