namespace Homemade.Data
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Homemade.Models.EntityModels;
    using Contracts;

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

            defaultCategories.Add(new Category() { Name = "Other" });
            defaultCategories.Add(new Category() { Name = "Breads" });
            defaultCategories.Add(new Category() { Name = "Sweets" });
            defaultCategories.Add(new Category() { Name = "Nuts" });
            defaultCategories.Add(new Category() { Name = "Drinks" });
            defaultCategories.Add(new Category() { Name = "Vegetables and Fruits" });
            defaultCategories.Add(new Category() { Name = "Meat and Fish" });

            defaultProducts.Add(new Product()
            {
                Name = "Chicken Meat",
                Category = defaultCategories[6],
                Description = "Chicken meant.....",
                Price = 5,
                Date = DateTime.Now
            });

            defaultProducts.Add(new Product()
            {
                Name = "Apple",
                Category = defaultCategories[5],
                Description = "Green delicious apples!",
                Price = 1,
                Date = DateTime.Now
            });

            defaultProducts.Add(new Product()
            {
                Name = "Cashews",
                Category = defaultCategories[3],
                Description = "Cashew nuts. Very healthy!",
                Price = 2,
                Date = DateTime.Now
            });

            defaultProducts.Add(new Product()
            {
                Name = "Milka Chokolate",
                Category = defaultCategories[2],
                Description = "This is absolutely no product that couse addiction...",
                Price = 3,
                Date = DateTime.Now
            });

            defaultProducts.Add(new Product()
            {
                Name = "Normal Bread",
                Category = defaultCategories[1],
                Description = "What is soup without bread?!",
                Price = 1,
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

            var roleStore = new RoleStore<IdentityRole>(context);
            var rolemanager = new RoleManager<IdentityRole>(roleStore);

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };

                rolemanager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var role = new IdentityRole { Name = "User" };

                rolemanager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var passwordHash = new PasswordHasher();
                string password = passwordHash.HashPassword("admin");
                var user = new HomemadeUser
                {
                    UserName = "admin",
                    Email = "admin@abv.bg",
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                context.Users.Add(user);
                var cart = new ShoppingCart() { Owner = user };
                context.ShoppingCarts.Add(cart);
                user.ShoppingCart = cart;
                context.SaveChanges();

                var userStore = new UserStore<HomemadeUser>(context);
                var userManager = new UserManager<HomemadeUser>(userStore);
                userManager.AddToRole(user.Id, "Admin");
            }

            base.Seed(context);
        }
    }
}
