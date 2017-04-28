namespace Homemade.Run.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Models;
    using Homemade.Models.EntityModels;

    public class ShoppingCartController : Controller
    {
        public ActionResult Index()
        {
            UserService userService = new UserService();
            ShoppingCartService cartService = new ShoppingCartService();

            if (!User.Identity.IsAuthenticated)
            {
                //TODO: come back here...
                string cartInformation = Request.Cookies["sesid"].Value;

                if (string.IsNullOrEmpty(cartInformation))
                {
                    return View();
                }
            }

            string userId = User.Identity.GetUserId();
            HomemadeUser user = userService.GetUserById(userId);

            ShoppingCart cart = cartService.GetByUser(user);

            return View(cart);
        }
    }
}