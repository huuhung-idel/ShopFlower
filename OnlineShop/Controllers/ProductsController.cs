using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        } 

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }
        public  ActionResult Category(long cateID)
        {
          
            var category = new CategoryDao().ViewDetail(cateID);
            ViewBag.Category = category;
            var model = new ProductDao().ListByCategoryId(cateID);
            return View(model);
        }

        public ActionResult Detail(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID.Value);
            ViewBag.RelateProducts = new ProductDao().ListRelateProducts(id);
            return View(product);
        }
        public ActionResult ProductAll()
        {
            ViewBag.productAll = new ProductDao().ListAll();
            return View();
        }
    }
}