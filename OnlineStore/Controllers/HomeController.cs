using Model.Dao;
using OnlineStore.Common;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(4);
            ViewBag.ListFeatureProducts= productDao.ListFeatureProduct(4);
            return View();
        }
        [ChildActionOnly]
        public ActionResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }
        public ActionResult Author()
        {
            var model = new AuthorDao().ListAll();
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
    }
}