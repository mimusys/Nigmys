using Homer_MVC.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        public JsonResult CheckUsername(String username) {
            return Json(!userSql.doesUsernameExist(username));
        }

        [HttpPost]
        public JsonResult CheckEmail(String email) {
            return Json(!userSql.doesEmailExist(email));
        }

        [HttpPost]
        public JsonResult NewUser(User user) {
            int userId = userSql.addNewUser(user);
            if (userId != -1) {
                user.UserID = userId.ToString();
                Session["user"] = user;
                return Json(true);
            }
            return Json(false);
        }

        [HttpPost]
        public JsonResult UploadPicture() {
            var file = Request.Files[0];
            if (Session["user"] != null && file != null) {
                User user = (User)Session["user"];
                var filename = user.UserID + Path.GetExtension(file.FileName);
                string urlPath = "~/Images/Profile/" + filename;
                Directory.CreateDirectory(Server.MapPath("~/Images/Profile"));
                var path = Path.Combine(Server.MapPath("~/Images/Profile/"), filename);
                file.SaveAs(path);
                if (userSql.setProfileUrl(user.UserID, urlPath)) {
                    return Json(true);
                }
            }
            return Json(false);
        }
    }
}