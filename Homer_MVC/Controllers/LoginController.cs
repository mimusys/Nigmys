using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Homer_MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISqlDatabase userSql;
        [InjectionConstructor]
        public LoginController(SqlUserDatabase userSql)
        {
            this.userSql = userSql;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(string username, string password)
        {
            return Json(new {Message = userSql.GetConnString(), Username = username, Password = password });
        }

    }
}
