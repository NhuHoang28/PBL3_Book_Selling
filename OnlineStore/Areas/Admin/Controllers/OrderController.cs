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
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new OrderDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        public ActionResult Edit(long id)
        {
            var user = new OrderDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(DonHang order)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDao();
                var result = dao.Update1(order);
                if (result)
                {
                    SetAlert("Sửa đơn hàng thành công", "success");
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công"); // them ko thanh cong tra ve trang create
                }
            }
            return View("Index");
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
            return RedirectToAction("Index", "Home");
        }
    }
}