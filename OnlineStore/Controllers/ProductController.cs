using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int page=1, int pageSize=100)
        {
            int totalRecord = 0;
            ViewBag.AllProducts = new ProductDao().ListAllProduct(ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View();
        }
        public ActionResult Category(string id)
        {
            ViewBag.Category = new ProductCategoryDao().ViewDetail(id);
            ViewBag.ListCategoryProducts = new ProductDao().ListCategoryProduct(id);
            return View();
        }
        public ActionResult Author(string id)
        {
            ViewBag.Author = new ProductCategoryDao().ViewDetailAuthor(id);
            ViewBag.ListAuthorProducts = new ProductDao().ListAuthorProduct(id);
            return View();
        }
        public ActionResult Detail(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.MaLoaiSach);
            ViewBag.RelatedProducts = new ProductDao().ListRelatedProduct(id);
            return View(product);
        }
        public ActionResult Search(string keyword)
        {
            ViewBag.SearchProduct= new ProductDao().Search(keyword);
            return View();
        }
    }
}