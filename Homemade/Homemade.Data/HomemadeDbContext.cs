namespace Homemade.Data
{
    using System.Data.Entity;
    using Homemade.Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class HomemadeDbContext : IdentityDbContext<HomemadeUser>
    {
        public HomemadeDbContext()
            : base("name=HomemadeDbContext")
        {
        }

        public static HomemadeDbContext Create()
        {
            return new HomemadeDbContext();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Subcategory> Subcategory { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<Address> UserAddresses { get; set; }
    }
}
