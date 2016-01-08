using Homer_MVC.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homer_MVC.Controllers {
    [LoggedInFilter]
    public class InvestmentsController : Controller {

        public ActionResult AddInvestment() {
            return View();
        }
    }
}