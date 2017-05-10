namespace Homemade.Data.Contracts
{
    using Homemade.Models.EntityModels;

    public interface IUnitOfWork
    {
        IRepository<CartProduct> CartProducts { get; set; }

        IRepository<Category> Categories { get; set; }

        IRepository<Order> Orders { get; set; }

        IRepository<Product> Products { get; set; }

        IRepository<ShoppingCart> ShoppingCarts { get; set; }

        IUserRepository Users { get; set; }

        void Commit();
    }
}
