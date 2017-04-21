using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homemade.Run.Controllers
{
    [Authorize]
    public class MyProductsController : Controller
    {
        // GET: MyProducts
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyProducts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyProducts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: MyProducts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyProducts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: MyProducts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyProducts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
