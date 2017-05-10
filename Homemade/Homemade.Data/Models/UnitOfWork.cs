namespace Homemade.Data.Models
{
    using Homemade.Data.Contracts;
    using Homemade.Models.EntityModels;

    public class UnitOfWork : IUnitOfWork
    {
        private HomemadeDbContext _context;

        public UnitOfWork(HomemadeDbContext context = null)
        {
            this._context = context ?? new HomemadeDbContext();
            this.CartProducts = new Repository<CartProduct>(this._context);
            this.Categories = new Repository<Category>(this._context);
            this.Orders = new Repository<Order>(this._context);
            this.Products = new Repository<Product>(this._context);
            this.ShoppingCarts = new Repository<ShoppingCart>(this._context);
            this.Users = new UserRepository(this._context);
        }

        public IRepository<CartProduct> CartProducts { get; set; }

        public IRepository<Category> Categories { get; set; }

        public IRepository<Order> Orders { get; set; }

        public IRepository<Product> Products { get; set; }

        public IRepository<ShoppingCart> ShoppingCarts { get; set; }

        public IUserRepository Users { get; set; }

        public void Commit()
        {
            this._context.SaveChanges();
        }
    }
}
