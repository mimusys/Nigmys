﻿using Nigmys.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Nigmys.Controllers
{
    [LoggedInFilter]
    public class DashboardController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

    }
}
