using Model.Dao;
using OnlineStore.Areas.Admin.Data;
using OnlineStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model) // Login la 1 action trong Controller Login
        {
            if (ModelState.IsValid) // kiem tra form khac rong~
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.IdUser;

                    Session.Add(CommonConstants.USER_SESSION, userSession); // them moi 1 doi tuong vao session ,,session la vung nho tam thoi
                    // dung session nay de truyen du lieu vao dung trong trang index ben duoi
                    return RedirectToAction("Index", "Home"); // chuyen den trang index cua view home
                }
                else if (result == -1)
                {
                    var user = dao.GetByName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.IdUser;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return Redirect("/");
                    //ModelState.AddModelError("", "Tài khoản không có quyền truy cập");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
            }
            return View("Index"); // dang nhap ko dc tra ve view
        }
    }
}