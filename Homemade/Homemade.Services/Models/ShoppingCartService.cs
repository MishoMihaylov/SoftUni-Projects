namespace Homemade.Services.Models
{
    using System.Linq;
    using Homemade.Models.EntityModels;
    using Homemade.Services.Contracts;

    public class ShoppingCartService : BaseService, IShoppingCartService
    {
        public void AddOrUpdate(ShoppingCart shoppingCart)
        {
            this.UnitOfWork.ShoppingCarts.AddOrUpdate(shoppingCart);
            this.UnitOfWork.Commit();
        }

        public ShoppingCart GetByUser(string username)
        {
            return this.UnitOfWork.ShoppingCarts.FindBy(sc => sc.Owner.UserName == username).Single();
        }

        public void AddProduct(ShoppingCart shoppingCart, CartProduct product)
        {
            if(product.Product == null)
            {
                product.Product = this.UnitOfWork.Products.FindById(product.ProductId);
            }

            this.UnitOfWork.ShoppingCarts.FindBy(cart => cart.Id == shoppingCart.Id).Single().Items.Add(product);
            this.UnitOfWork.ShoppingCarts.AddOrUpdate(shoppingCart);
            this.UnitOfWork.Commit();
        }

        public void DeleteProduct(ShoppingCart shoppingCart, int productId)
        {
            var item = shoppingCart.Items.Where(i => i.Id == productId).Single();
            shoppingCart.Items.Remove(item);
            this.UnitOfWork.ShoppingCarts.AddOrUpdate(shoppingCart);
            this.UnitOfWork.Commit();
        }

        public void Clear(ShoppingCart shoppingCart)
        {
            shoppingCart.Items.Clear();
            this.UnitOfWork.ShoppingCarts.AddOrUpdate(shoppingCart);
            this.UnitOfWork.Commit();
        }
    }
}
