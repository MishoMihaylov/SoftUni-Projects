namespace Homemade.Services.Models
{
    using System.Linq;
    using Homemade.Models.EntityModels;

    public class ShoppingCartService : BaseService<ShoppingCart>
    {
        public void AddOrUpdate(ShoppingCart shoppingCart)
        {
            this.Repository.AddOrUpdate(shoppingCart);
        }

        public ShoppingCart GetByUser(string username)
        {
            return (ShoppingCart)this.Repository.FindBy(sc => sc.Owner.UserName == username);
        }

        public void AddProduct(ShoppingCart shoppingCart, CartProduct product)
        {
            shoppingCart.Items.Add(product);
            this.Repository.AddOrUpdate(shoppingCart);
        }

        public void DeleteProduct(ShoppingCart shoppingCart, int productId)
        {
            var item = shoppingCart.Items.Where(i => i.Id == productId).Single();
            shoppingCart.Items.Remove(item);
            this.Repository.AddOrUpdate(shoppingCart);
        }

        public void DeleteProduct(ShoppingCart shoppingCart, CartProduct product)
        {
            shoppingCart.Items.Remove(product);
            this.Repository.AddOrUpdate(shoppingCart);
        }

        public void Clear(ShoppingCart shoppingCart)
        {
            shoppingCart.Items.Clear();
            this.Repository.AddOrUpdate(shoppingCart);
        }
    }
}
