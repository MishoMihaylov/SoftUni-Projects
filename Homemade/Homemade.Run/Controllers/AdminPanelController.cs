
namespace Homemade.Run.Controllers
{
    using System.Web.Mvc;

    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class AdminPanelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return RedirectToAction("AddProduct", "Products");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CheckNewOrders()
        {

            return this.View();
        }

        [HttpGet]
        public ActionResult CheckSentOrders()
        {

            return this.View();
        }

        [HttpPost]
        public ActionResult IsShipped(int orderId)
        {

            return this.RedirectToAction("CheckNewOrders");
        }

        [HttpPost]
        public ActionResult IsNotShipped(int orderId)
        {
            

            return this.View("CheckSentOrders");
        }
    }
}