namespace Homemade.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Homemade.Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Contracts;
    
    using Microsoft.AspNet.Identity;

    public class HomemadeDbContext : IdentityDbContext<HomemadeUser>, IHomemadeDbContext
    {
        public HomemadeDbContext()
            : base("HomemadeDb")
        {
            Database.SetInitializer(new HomemadeDbInitializer());
        }

        public static HomemadeDbContext Create()
        {
            return new HomemadeDbContext();
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        public IDbSet<CartProduct> CartProducts { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Address> UserAddresses { get; set; }
    }

    public class HomemadeDbInitializer : DropCreateDatabaseAlways<HomemadeDbContext>
    {
        protected override void Seed(HomemadeDbContext context)
        {
            IList<Category> defaultCategories = new List<Category>();
            IList<Product> defaultProducts = new List<Product>();


            defaultCategories.Add(new Category() { Name = "Food"});
            defaultCategories.Add(new Category() { Name = "Drinks" });

            defaultProducts.Add(new Product()
            {
                Name = "First",
                Category = defaultCategories[0],
                Price = 5,
                Quantity = 10,
                Date = DateTime.Now
            });

            defaultProducts.Add(new Product()
            {
                Name = "Second",
                Category = defaultCategories[1],
                Price = 5,
                Quantity = 10,
                Date = DateTime.Now
            });

            defaultProducts.Add(new Product()
            {
                Name = "Third",
                Category = defaultCategories[0],
                Price = 5,
                Quantity = 10,
                Date = DateTime.Now
            });


            foreach (Category category in defaultCategories)
            {
                context.Categories.Add(category);
            }

            foreach (Product product in defaultProducts)
            {
                context.Products.Add(product);
            }

            if (!context.Users.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore = new UserStore<HomemadeUser>(context);
                var userManager = new UserManager<HomemadeUser>(userStore);

                var role = roleManager.FindByName("Admin");
                if (role == null)
                {
                    role = new IdentityRole("Admin");
                    roleManager.Create(role);
                }

                var user = userManager.FindByName("admin");
                if (user == null)
                {
                    var newUser = new HomemadeUser()
                    {
                        UserName = "admin",
                        Email = "aaa@aaa.net",
                        PhoneNumber = "5551234567",
                    };
                    userManager.Create(newUser, "pass");
                    userManager.SetLockoutEnabled(newUser.Id, false);
                    userManager.AddToRole(newUser.Id, "Admin");
                }
            }

            base.Seed(context);
        }
    }
}
