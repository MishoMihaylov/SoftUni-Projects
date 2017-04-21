namespace Homemade.Run.Controllers
{
    using System.Web.Mvc;

    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {

            if (!User.Identity.IsAuthenticated)
            {
                string cartInformation = Request.Cookies["sesid"].Value;

                if (string.IsNullOrEmpty(cartInformation))
                {
                    //TODO:...
                }

                //get the session cart
            }

            return View();
        }
    }
}