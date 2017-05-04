namespace Homemade.Run.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Services.Models;
    using Homemade.Models.EntityModels;
    using Homemade.Models.BindingModels;

    public class ProductsController : Controller
    {
        private CategoryService _categoryService = new CategoryService();
        private ProductsService _productsService = new ProductsService();

        public ActionResult Index()
        {
            List<Product> allProducts = this._productsService.GetAll().OrderBy(product => product.Date).ToList();

            return View(allProducts);
        }

        [Authorize]
        public ActionResult MyProducts()
        {
            List<Product> myProducts = _productsService.GetByManufacturer(User.Identity.Name).ToList();

            return View(myProducts);
        }

        [Authorize]
        public ActionResult AddProduct()
        {
            List<Category> categories = this._categoryService.GetAll().ToList();

            List<SelectListItem> categoriesListItems = new List<SelectListItem>();

            foreach (var category in categories)
            {
                SelectListItem item = new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                };

                categoriesListItems.Add(item);
            }

            ViewBag.Categories = categoriesListItems;

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddProduct(ProductBM product)
        {
            //Product product = AutoMapper.Mapper.Map<Product>(); 

            //Replace with mapped product
            Product newProduct = new Product();
            newProduct.Producer = User.Identity.Name;

            this._productsService.AddOrUpdate(newProduct);

            return RedirectToAction("MyProducts");
        }

        public ActionResult Details(int productId)
        {
            Product product = _productsService.GetById(productId);

            return View(product);
        }

        [Authorize]
        [HttpDelete]
        public ActionResult Remove(int productId)
        {
            if(_productsService.GetById(productId).Producer != User.Identity.Name)
            {
                return View();
            }

            _productsService.Remove(productId);
            return View();
        }

        public ActionResult ByCategory(int categoryId)
        {
            if (_categoryService.GetById(categoryId) == null)
            {
                return View();
            }

            ICollection<Product> matchedProducts = _categoryService.GetById(categoryId).Products;

            return View(matchedProducts);
        }

        public ActionResult GetCategories()
        {
            List<Category> categories = _categoryService.GetAll().ToList();

            return PartialView("ProductsSubmenuPartial", categories);
        }
    }
}
