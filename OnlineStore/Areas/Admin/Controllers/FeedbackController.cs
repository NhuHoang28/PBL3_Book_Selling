using Model.Dao;
using OnlineStore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {
        // GET: Admin/Feedback
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new FeedbackDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
    }
}