namespace Homemade.Run.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Models;
    using Homemade.Models.EntityModels;
    using System.Collections.Generic;
    using Homemade.Data.Models;

    public class ShoppingCartController : Controller
    {
        public ActionResult Index()
        {
            //TODO: Refactor the repository!!!
            Repository<HomemadeUser> userRepo = new Repository<HomemadeUser>();
            UserService userService = new UserService();
            ShoppingCartService cartService = new ShoppingCartService();

            if (!User.Identity.IsAuthenticated)
            {
                //TODO: come back here...
                List<int> cartInformation = (List<int>)Session["cartItems"];

                if (cartInformation.Count == 0)
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