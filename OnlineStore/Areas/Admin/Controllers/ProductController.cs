using Model.Dao;
using Model.EF;
using OnlineStore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                product.NgayTao = DateTime.Now;
                long id = dao.Insert(product);
                if (id != 0)
                {
                    SetAlert("Thêm User thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công"); // them ko thanh cong tra ve trang create
                    return View("Create");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(long id)
        {
            var user = new ProductDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(SanPham product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);
                if (result)
                {
                    SetAlert("Sửa sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công"); // them ko thanh cong tra ve trang create
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}