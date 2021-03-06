﻿using Nigmys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nigmys.Controllers
{
    public class LandingPageController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public String GetUsername() {
            User user = (User)Session["user"];
            if (user != null) {
                return user.Username;
            } else {
                return "Login/Signup";
            }
        }

        public String GetLoginUrl() {
            if (Session["user"] == null) {
                return "/CommonViews/Login";
            } else {
                return "/Profile/Index";
            }
        }
    }
}
