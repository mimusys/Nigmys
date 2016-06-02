using Nigmys.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Nigmys.Controllers
{
    public class RegistrationController : Controller {

        public ActionResult SignUp()
        {

            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }
        
    }
}