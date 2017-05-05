namespace Homemade.Run.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Homemade.Models.EntityModels;
    using Services.Models;

    //[Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private OrdersService _ordersService = new OrdersService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return RedirectToAction("AddProduct", "Products");
        }

        //Both below can use the same view

        public ActionResult ConfirmedOrders()
        {
            List<Order> confirmedOrders = this._ordersService.GetConfirmed().ToList();

            return this.View(confirmedOrders);
        }

        public ActionResult NonConfirmedOrders()
        {
            List<Order> nonConfirmedOrders = this._ordersService.GetNonConfirmed().ToList();

            return this.View(nonConfirmedOrders);
        }

        [HttpPost]
        public ActionResult IsShipped(int orderId)
        {
            return this.RedirectToAction("CheckNewOrders");
        }

        [HttpPost]
        public ActionResult IsNotShipped(int orderId)
        {
            return this.RedirectToAction("CheckSentOrders");
        }
    }
}