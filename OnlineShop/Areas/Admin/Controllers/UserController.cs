using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString,int page=1, int pageSize=2)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {

            
            var dao = new UserDao();
            long id = dao.Insert(user);
            if (id > 0)
            {
                SetAlert("Add User finish","success");
                return RedirectToAction("Index", "User");

            }
            else
            {
                ModelState.AddModelError("", "Add User failed");
            }
            }return View("Index");

        }


        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {


                var dao = new UserDao();
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Update User finish", "success");
                    return RedirectToAction("Index", "User");

                }
                else
                {
                    ModelState.AddModelError("", "Update failed");
                }
            }
            return View("Index");

        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            SetAlert("Delete User finish", "success");
            return RedirectToAction("Index");
        }

     
    }
}