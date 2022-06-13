using OnlineStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineStore.Controllers
{
    public class BaseController : Controller // kiem tra neu Session = null thi tra ve trang dang nhap, dung cho moi trang
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {

                {
                    filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "User", action = "Login", Area = "" }));
                }


            }
            base.OnActionExecuting(filterContext);
        }
        protected void SetAlert(string message, string type) // bootstrap
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }

}