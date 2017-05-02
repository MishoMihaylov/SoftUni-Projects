namespace Homemade.Run.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("/About")]
        public ActionResult About()
        {
            return View();
        }

        [Route("/Contact")]
        public ActionResult Contact()
        {
            return View();
        }
    }
}