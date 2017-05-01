namespace Homemade.Data
{
    using System.Data.Entity;
    using Homemade.Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Contracts;

    //TODO: Check if these interfaces can couse any problem

    public class HomemadeDbContext : IdentityDbContext<HomemadeUser>, IHomemadeDbContext
    {
        public HomemadeDbContext()
            : base("HomemadeDb")
        {
        }

        public static HomemadeDbContext Create()
        {
            return new HomemadeDbContext();
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        public IDbSet<Address> UserAddresses { get; set; }
    }
}
