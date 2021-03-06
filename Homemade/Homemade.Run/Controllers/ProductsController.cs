﻿namespace Homemade.Run.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Services.Models;
    using Homemade.Models.EntityModels;
    using Homemade.Models.BindingModels;
    using Homemade.Models.ViewModels;
    using System.Web;

    public class ProductsController : Controller
    {
        private CategoryService _categoryService = new CategoryService();
        private ProductsService _productsService = new ProductsService();

        public ActionResult Index(int categoryId = -1)
        {
            List<Category> categories = this._categoryService.GetAll().ToList();
            List<CategoryVM> categoriesVMs = AutoMapper.Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryVM>>(categories).ToList();
            categoriesVMs.Insert(0, new CategoryVM() { Id = -1, Name = "All" });
            List<Product> allProducts = new List<Product>();

            if (categoryId == -1)
            {
                allProducts = this._productsService.GetAll().OrderBy(product => product.Date).ToList();
            }
            else
            {
                allProducts = this._productsService.GetByCategoryId(categoryId).OrderBy(product => product.Date).ToList();
            }

            ViewBag.Categories = categoriesVMs;

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
            newProduct.CategoryId = int.Parse(product.Category);
            this._productsService.AddOrUpdate(newProduct);

            return RedirectToAction("Index", "AdminPanel");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            try
            {
                this._productsService.GetById(id);
            }
            catch (Exception)
            {
                this.RedirectToAction("Index", "Products");
            }

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

            Product product = this._productsService.GetById(id);
            ProductBM bindModel = AutoMapper.Mapper.Map<Product, ProductBM>(product);
            this.ViewBag.ItemId = id;

            return this.View(bindModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(ProductBM product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            Product editedProduct = this._productsService.GetById(product.Id);
            editedProduct.Name = product.Name;
            editedProduct.Description = product.Description;
            editedProduct.Price = product.Price;
            editedProduct.CategoryId = int.Parse(product.Category);
            editedProduct.Category = null;

            this._productsService.AddOrUpdate(editedProduct);

            return RedirectToAction("Index", "Products");
        }

        public ActionResult Details(int productId)
        {
            Product product = _productsService.GetById(productId);

            return View(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Remove(int productId)
        {
            _productsService.Remove(productId);

            return this.RedirectToAction("Index");
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
