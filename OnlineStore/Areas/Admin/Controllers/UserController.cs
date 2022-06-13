using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using OnlineStore.Common;
using PagedList; // pagelist de dùng cho view
using OnlineStore.Areas.Admin.Controllers;
using OnlineStore.Controllers;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/Admin
        public ActionResult Index(int page=1,int pageSize=10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(long id)
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
                var encryptedMD5pas = Encryptor.MD5Hash(user.PassWord);
                user.PassWord = encryptedMD5pas;
                user.NgayTao = DateTime.Now;
                long id = dao.Insert(user);
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
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.PassWord)) //kiem tra neu ko nhap password 
                {
                    var encryptedMD5pas = Encryptor.MD5Hash(user.PassWord);
                    user.PassWord = encryptedMD5pas;
                }
                
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Sửa User thành công","success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công"); // them ko thanh cong tra ve trang create
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}