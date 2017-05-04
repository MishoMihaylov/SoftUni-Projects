namespace Homemade.Models.EntityModels
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public Guid Id { get; set; }

        public bool Ordered { get; set; }

        public string Buyer { get; set; }

        public DateTime Date { get; set; }

        public bool Confirmed { get; set; }
        
        public ICollection<Product> OrderedProducts { get; set; }
    }
}
