namespace Homemade.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order()
        {
            this.OrderedProducts = new HashSet<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }

        public string Buyer { get; set; }

        public DateTime Date { get; set; }

        public bool Confirmed { get; set; }

        public string ShippingAddress { get; set; }
        
        public virtual ICollection<OrderProduct> OrderedProducts { get; set; }
    }
}
