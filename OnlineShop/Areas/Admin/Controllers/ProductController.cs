using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string search, int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAll(search, page, pageSize);
            ViewBag.Search = search;
            return View(model);
         
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long id = dao.Insert(product);
                if (id > 0)
                {
                    SetAlert("Add Product finish", "success");
                    return RedirectToAction("Index", "Product");

                }
                else
                {
                    ModelState.AddModelError("", "Add Product failed");
                }
            }
            return View("Index");

        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);
                if (result)
                {
                    SetAlert("Update Product finish", "success");
                    return RedirectToAction("Index", "Product");

                }
                else
                {
                    ModelState.AddModelError("", "Update failed");
                }
            }
            return View("Index");

        }
        public ActionResult Edit(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }
    }
}