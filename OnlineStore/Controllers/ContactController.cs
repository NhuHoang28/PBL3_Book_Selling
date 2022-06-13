using Model.Dao;
using Model.EF;
using OnlineStore.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(string content)
        {
            long iduser = new UserDao().getIdUser();
            var feedback = new GopY_KH();
            feedback.IdUser = iduser;
            feedback.NoiDung = content;
            feedback.NgayTao = DateTime.Now;
            feedback.TrangThai = true;
            try
            {
                var id1 = new ContactDao().Insert(feedback);
            }
            catch (Exception e)
            {
                return Redirect("/loi-gui-don");
            }
            return Redirect("/Contact/Success");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}