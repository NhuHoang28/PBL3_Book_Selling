using Model.Dao;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Admin/Statistic
        static Statistic s1 = new Statistic();
        public ActionResult Index()
        {
            return View(s1);
        }
        public ActionResult Sum(DateTime firstdate, DateTime lastdate)
        {
            s1.sum=new OrderDao().Sum(firstdate, lastdate);
            s1.quantity=new OrderDao().Quantity(firstdate, lastdate);
            s1.firstdate = firstdate;
            s1.lastdate = lastdate;
            return RedirectToAction("Index");
        }
    }
}