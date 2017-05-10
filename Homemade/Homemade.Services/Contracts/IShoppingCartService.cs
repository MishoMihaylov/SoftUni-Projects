namespace Homemade.Services.Contracts
{
    using Homemade.Models.EntityModels;

    public interface IShoppingCartService
    {
        void AddOrUpdate(ShoppingCart shoppingCart);

        ShoppingCart GetByUser(string username);

        void AddProduct(ShoppingCart shoppingCart, CartProduct product);

        void DeleteProduct(ShoppingCart shoppingCart, int productId);

        void Clear(ShoppingCart shoppingCart);
    }
}
