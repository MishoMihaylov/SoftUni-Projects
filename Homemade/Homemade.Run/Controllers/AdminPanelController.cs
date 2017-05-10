namespace Homemade.Run.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Homemade.Models.EntityModels;
    using Services.Models;
    using Homemade.Models.ViewModels;

    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private OrdersService _ordersService = new OrdersService();
        private UserService _userService = new UserService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmedOrders()
        {
            List<Order> confirmedOrders = this._ordersService.GetConfirmed().ToList();
            List<OrderVM> ordersVMs = new List<OrderVM>();

            foreach (var order in confirmedOrders)
            {
                OrderVM orderVM = AutoMapper.Mapper.Map<Order, OrderVM>(order);
                var orderedProducts = AutoMapper.Mapper.Map<ICollection<OrderProduct>, ICollection<ProductVM>>(order.OrderedProducts);
                orderVM.OrderedProducts = orderedProducts;
                ordersVMs.Add(orderVM);
            }

            ordersVMs.Reverse();

            return this.View(ordersVMs);
        }

        public ActionResult NonConfirmedOrders()
        {
            List<Order> confirmedOrders = this._ordersService.GetNonConfirmed().ToList();
            List<OrderVM> ordersVMs = new List<OrderVM>();

            foreach (var order in confirmedOrders)
            {
                OrderVM orderVM = AutoMapper.Mapper.Map<Order, OrderVM>(order);
                var orderedProducts = AutoMapper.Mapper.Map<ICollection<OrderProduct>, ICollection<ProductVM>>(order.OrderedProducts);
                orderVM.OrderedProducts = orderedProducts;
                ordersVMs.Add(orderVM);
            }

            return this.View(ordersVMs);
        }

        [HttpPost]
        public ActionResult IsShipped(int orderId)
        {
            this._ordersService.ChangeState(orderId);

            return this.RedirectToAction("NonConfirmedOrders");
        }
    }
}