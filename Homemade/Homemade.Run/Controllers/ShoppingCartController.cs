namespace Homemade.Run.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Services.Models;
    using Homemade.Models.EntityModels;
    using Homemade.Models.BindingModels;
    using Homemade.Models.ViewModels;
    using System;

    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _shoppingCartService = new ShoppingCartService();
        private readonly ProductsService _productService = new ProductsService();
        private readonly OrdersService _orderService = new OrdersService();

        public ActionResult Index()
        {
            string currentUsername = User.Identity.Name;

            ShoppingCart cart = this._shoppingCartService.GetByUser(currentUsername);
            ShoppingCartVM cartVM = new ShoppingCartVM();
            cartVM.CartItems = AutoMapper.Mapper.Map<ICollection<CartProduct>, ICollection<CartProductVM>>(cart.Items);

            return View(cartVM);
        }

        public ActionResult Order()
        {
            //string currentUsername = User.Identity.Name;
            //ShoppingCart cart = this._shoppingCartService.GetByUser(currentUsername);
            //ShoppingCartVM cartVM = new ShoppingCartVM();
            //cartVM.CartItems = AutoMapper.Mapper.Map<ICollection<CartProduct>, ICollection<CartProductVM>>(cart.Items);
            //this.ViewBag.Cart = cartVM;

            return View();
        }

        [HttpPost]
        public ActionResult Order(AddressBM address)
        {
            if (!ModelState.IsValid)
            {
                return View(address);
            }

            string shippingAddress = "Address: " + address.ShippingAddress
                + Environment.NewLine + Environment.NewLine + "Town: " + address.Town 
                + Environment.NewLine + Environment.NewLine 
                + (string.IsNullOrEmpty(address.Description) ? ("Comments: " + address.Description) : ""); 

            Order currentOrder = new Order();
            currentOrder.Date = DateTime.Now;
            currentOrder.Confirmed = false;
            currentOrder.Buyer = User.Identity.Name;
            currentOrder.ShippingAddress = shippingAddress;

            string currentUsername = User.Identity.Name;
            ShoppingCart cart = this._shoppingCartService.GetByUser(currentUsername);

            foreach (var item in cart.Items)
            {
                OrderProduct orderItem = AutoMapper.Mapper.Map<CartProduct, OrderProduct>(item);
                currentOrder.OrderedProducts.Add(orderItem);
            }

            this._orderService.AddOrUpdate(currentOrder);
            this._shoppingCartService.Clear(cart);

            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult InputAddress()
        {
            return PartialView(new AddressBM());
        }

        [HttpPost]
        public ActionResult AddToCart(int productId)
        {
            string currentUsername = User.Identity.Name;

            ShoppingCart shoppingCart = this._shoppingCartService.GetByUser(currentUsername);
            CartProduct cartProduct = shoppingCart.Items.Where(sc => sc.Product.Id == productId).FirstOrDefault();

            if (cartProduct != null)
            {
                cartProduct.Count++;
            }
            else
            {
                cartProduct = new CartProduct();
                cartProduct.Count = 1;
                cartProduct.ProductId = this._productService.GetById(productId).Id;
            }

            this._shoppingCartService.AddProduct(shoppingCart, cartProduct);

            return this.Content(cartProduct.Product.Name);
        }
    }
}