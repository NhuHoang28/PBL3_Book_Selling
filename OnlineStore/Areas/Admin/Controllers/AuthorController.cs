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
    public class AuthorController : BaseController
    {
        // GET: Admin/Author
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new AuthorDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TacGia author)
        {
            if (ModelState.IsValid)
            {
                var dao = new AuthorDao();
                string id = dao.Insert(author);
                if (id != null)
                {
                    SetAlert("Thêm tác giả thành công", "success");
                    return RedirectToAction("Index", "Author");
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
            var user = new AuthorDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(TacGia author)
        {
            if (ModelState.IsValid)
            {
                var dao = new AuthorDao();
                var result = dao.Update(author);
                if (result)
                {
                    SetAlert("Sửa tác giả thành công", "success");
                    return RedirectToAction("Index", "Author");
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
            new AuthorDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}