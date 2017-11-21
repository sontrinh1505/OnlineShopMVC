using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMVC.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var category = new CategoryModel().ListAll();
            return View(category);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var res = new CategoryModel().Create(category);

                    if(res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "The Category unsuccessfully create");
             
                }
                return View(category);
                // TODO: Add insert logic here

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Category/Edit/5
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

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Category/Delete/5
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
