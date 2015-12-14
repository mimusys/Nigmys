using Homer_MVC.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Homer_MVC.Controllers
{
    public class SignUpController : Controller {
        private ISqlUserDatabase userSql;

        [InjectionConstructor]
        public SignUpController(ISqlUserDatabase userSql) {
            this.userSql = userSql;
        }

        public ActionResult Index() {
            return View();
        }

    }
}