namespace Homemade.Models.ViewModels
{
    using System.Linq;
    using System.Collections.Generic;

    public class ShoppingCartVM
    {
        public ShoppingCartVM()
        {
            this.CartItems = new HashSet<CartProductVM>();
        }

        public decimal TotalPrice
        {
            get
            {
                return this.CartItems.Sum(item => item.Price * item.Quantity);
            }
        }

        public ICollection<CartProductVM> CartItems { get; set; }
    }
}
