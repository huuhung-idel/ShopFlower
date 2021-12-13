using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page=1, int pageSize=10)
        {
            var dao = new ContentDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [AllowHtml]
        public string Detail { get; set; }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? selectedID = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Content content)
        {
            if (ModelState.IsValid)
            {


                var dao = new ContentDao();
                long id = dao.Insert(content);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Content");

                }
                else
                {
                    ModelState.AddModelError("", "Create Content finish");
                }
            }
            SetViewBag();
            return View("Index");

        }


        public ActionResult Edit(int id)
        {
            var content = new ContentDao().ViewDetail(id);
            return View(content);
        }


        [HttpPost]
        public ActionResult Edit(Content content)
        {
            if (ModelState.IsValid)
            {


                var dao = new ContentDao();
                var result = dao.Update(content);
                if (result)
                {
                    return RedirectToAction("Index", "Content");

                }
                else
                {
                    ModelState.AddModelError("", "Update false");
                }
            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ContentDao().Delete(id);
            return RedirectToAction("Index");
        }
    }



}