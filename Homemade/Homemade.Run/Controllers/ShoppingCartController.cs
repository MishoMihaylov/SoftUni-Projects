namespace Homemade.Run.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Data.Models;
    using Services.Models;
    using Homemade.Models.EntityModels;

    [Authorize]
    public class ShoppingCartController : Controller
    {
        private ShoppingCartService _shoppingCartService = new ShoppingCartService();
        private ProductsService _productService = new ProductsService();

        public ActionResult Index()
        {
            Repository<HomemadeUser> userRepo = new Repository<HomemadeUser>();
            UserService userService = new UserService();
            ShoppingCartService cartService = new ShoppingCartService();

            string currentUsername = User.Identity.GetUserName();
            
            ShoppingCart cart = cartService.GetByUser(currentUsername);

            return View(cart);
        }

        public ActionResult Order()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlaceOrder(Order order)
        {
            //TODO: Order bind model needs to be here
            Repository<Order> repo = new Repository<Order>();

            repo.AddOrUpdate(order);

            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult ConfirmOrders()
        {
            Repository<Order> repo = new Repository<Order>();

            List<Order> allOrders = repo.GetAll().OrderBy(o => o.Confirmed).ThenBy(or => or.Date).ToList();

            return View();
        }

        [HttpPost]
        public void AddToCart(int productId)
        {
            string currentUsername = User.Identity.Name;

            ShoppingCart shoppingCart = this._shoppingCartService.GetByUser(currentUsername);
            CartProduct existingItem = shoppingCart.Items.Where(sc => sc.Product.Id == productId).FirstOrDefault();

            if (existingItem != null)
            {
                existingItem.Count++;
            }
            else
            {
                existingItem = new CartProduct();
                Product product = this._productService.GetById(productId);

                existingItem.Count = 1;
                existingItem.Product = product;
                existingItem.Cart = shoppingCart;

                shoppingCart.Items.Add(existingItem);
            }
        }
    }
}