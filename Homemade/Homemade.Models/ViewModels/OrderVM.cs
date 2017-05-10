namespace Homemade.Models.ViewModels
{
    using System.Collections.Generic;

    public class OrderVM
    {
        public int Id { get; set; }

        public string Buyer { get; set; }

        public bool Confirmed { get; set; }

        public string ShippingAddress { get; set; }

        public virtual ICollection<ProductVM> OrderedProducts { get; set; }
    }
}
