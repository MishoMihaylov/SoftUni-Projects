namespace Homemade.Data.Contracts
{ 
    using System.Data.Entity;
    using Homemade.Models.EntityModels;
    public interface IHomemadeDbContext
    {
        IDbSet<Product> Products { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        IDbSet<Address> UserAddresses { get; set; }
    }
}
