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
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/Author
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new ProductCategoryDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LoaiSach cate)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();
                cate.NgayTao = DateTime.Now;
                string id = dao.Insert(cate);
                if (id != null)
                {
                    SetAlert("Thêm loại sâch thành công", "success");
                    return RedirectToAction("Index", "ProductCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công"); // them ko thanh cong tra ve trang create
                    return View("Create");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(string id)
        {
            var cate = new ProductCategoryDao().ViewDetail(id);
            return View(cate);
        }
        [HttpPost]
        public ActionResult Edit(LoaiSach cate)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();
                var result = dao.Update(cate);
                if (result)
                {
                    SetAlert("Sửa loại sách thành công", "success");
                    return RedirectToAction("Index", "ProductCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công"); // them ko thanh cong tra ve trang create
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new ProductCategoryDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}