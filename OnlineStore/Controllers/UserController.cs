using Model.Dao;
using Model.EF;
using OnlineStore.Common;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string fullname, string username,string email,string address,string mobile,string gender,string password)
        {
            var user = new User();
            user.UserName = username;
            user.HoTen = fullname;
            user.Email = email;
            user.DiaChi = address;
            var encryptedMD5pas = Encryptor.MD5Hash(password);
            user.PassWord = encryptedMD5pas;
            user.TrangThai = true;
            user.DienThoai = mobile;
            user.NgayTao = DateTime.Now;
            user.TrangThai = false;
            if (gender=="Name") user.GioiTinh = true;
            else if(gender == "Nữ") user.GioiTinh = false;
            try
            {
                var id = new UserDao().Insert(user);
            }
            catch (Exception e)
            {
                
            }
            return RedirectToAction("Login","User");
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
        [HttpPost]
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
                    userSession.Status = user.TrangThai;

                    Session.Add(CommonConstants.USER_SESSION, userSession); // them moi 1 doi tuong vao session ,,session la vung nho tam thoi
                    // dung session nay de truyen du lieu vao dung trong trang index ben duoi
                    return RedirectToAction("Home","Admin"); // chuyen den trang index cua view home
                }
                else if (result == -1)
                {
                    var user = dao.GetByName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.IdUser;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
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
            return View("Login"); // dang nhap ko dc tra ve view
        }
        public ActionResult Edit(long id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
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
                    //SetAlert("Sửa User thành công", "success");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công"); // them ko thanh cong tra ve trang create
                }
            }
            return View("Index");
        }
        public ActionResult Order(long id,int page = 1, int pageSize = 10)
        {
            var dao = new OrderDao();
            var model = dao.ListOrderOfUser(id,page, pageSize);
            return View(model);
        }
        public ActionResult Detail(long id)
        {
            var detail = new OrderDetailDao().ViewDetail(id);
            return View(detail);
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new OrderDao().Delete(id);
            return RedirectToAction("Index","Home");
        }
    }
}