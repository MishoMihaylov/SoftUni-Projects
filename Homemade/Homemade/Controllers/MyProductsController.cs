namespace Homemade.Controllers
{
    using System.Web.Mvc;

    public class MyProductsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyProducts()
        {
            return View();
        }

        public ActionResult ProductDetails(int id)
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditProduct(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditProduct(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteProduct(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
