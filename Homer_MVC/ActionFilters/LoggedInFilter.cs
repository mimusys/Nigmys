using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Homer_MVC.ActionFilters {
    public class LoggedInFilter : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (filterContext.HttpContext.Session["user"] == null) {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "CommonViews", action = "Login" }));
                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
            }
        }
    }
}