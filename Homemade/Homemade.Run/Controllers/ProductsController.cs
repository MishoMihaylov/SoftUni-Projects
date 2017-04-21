namespace Homemade.Run.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Homemade.Models.EntityModels;
    using Services.Models;

    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Details(int categoryId)
        {
            ProductsService productService = new ProductsService();

            Product product = productService.GetById(categoryId);

            return View(product);
        }

        public ActionResult ByCategory(int categoryId)
        {
            CategoryService categoryService = new CategoryService();

            ICollection<Product> matchedProducts = categoryService.GetById(categoryId).Products;

            return View(matchedProducts);
        }
    }
}
