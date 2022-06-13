using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace OnlineStore.Controllers
{
    public class ProductCategoryController : Controller
    { // ko dung
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll() ;
            return PartialView(model);
        }
    }
}