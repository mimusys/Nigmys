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
        private readonly ISqlUserDatabase userSql;

        [InjectionConstructor]
        public LoginController(ISqlUserDatabase userSql)
        {
            this.userSql = userSql;
        }

        public ActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("Loading page");
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(string username, string password)
        {
            System.Diagnostics.Debug.WriteLine("Checking Login");


            String[] passwordInfo = userSql.getPasswordInfo(username);
            //String salt = "";
            //String hash = "";
            //if (passwordInfo != null)
            //{
            //    hash = passwordInfo[0];
            //    salt = passwordInfo[1];
            //}
            //else
            //{
            //    System.Diagnostics.Debug.WriteLine("Login was NOT Successful!");
            //}

            return Json(new { Hash = "hash", Salt = "salt" });
        }

    }
}
