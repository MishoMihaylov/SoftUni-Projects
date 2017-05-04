namespace Homemade.Run.Controllers
{
    using System;
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

        public ActionResult Index(int categoryId = -1)
        {
            List<Product> allProducts = new List<Product>();
            if (categoryId == -1)
            {
                allProducts = this._productsService.GetAll().OrderBy(product => product.Date).ToList();
            }
            else
            {
                allProducts = this._productsService.GetByCategoryId(categoryId).OrderBy(product => product.Date).ToList();
            }

            return View(allProducts);
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
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            Product newProduct = new Product();
            newProduct = AutoMapper.Mapper.Map<ProductBM, Product>(product);
            newProduct.Date = DateTime.Now;

            this._productsService.AddOrUpdate(newProduct);

            return RedirectToAction("MyProducts");
        }

        public ActionResult Details(int productId)
        {
            Product product = _productsService.GetById(productId);

            return View(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public void Remove(int productId)
        {
            _productsService.Remove(productId);
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
