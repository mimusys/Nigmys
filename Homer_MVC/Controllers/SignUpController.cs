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
    public class SignUpController : Controller
    {
        private ISqlUserDatabase userSql;
        private ISqlPortfolioDatabase portfolioSql;

        [InjectionConstructor]
        public SignUpController(ISqlUserDatabase userSql, ISqlPortfolioDatabase portfolioSql)
        {
            this.userSql = userSql;
            this.portfolioSql = portfolioSql;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CheckUsername(String username)
        {
            return Json(!userSql.doesUsernameExist(username));
        }

        [HttpPost]
        public JsonResult CheckEmail(String email)
        {
            return Json(!userSql.doesEmailExist(email));
        }

        [HttpPost]
        public JsonResult NewUser(User user)
        {
            user.PortfolioID = portfolioSql.createNewPortfolioID();
            int userId = userSql.addNewUser(user);
            if (userId != -1)
            {
                user.UserID = userId.ToString();
                Session["user"] = user;
                return Json(true);
            }
            else
            {
                portfolioSql.deletePortfolioID(user.PortfolioID);
            }
            return Json(false);
        }

        [HttpPost]
        public JsonResult UploadPicture()
        {
            var file = Request.Files[0];
            if (Session["user"] != null && file != null)
            {
                User user = (User)Session["user"];
                var filename = user.UserID + Path.GetExtension(file.FileName);
                string urlPath = "~/Images/Profile/" + filename;
                user.PictureURL = urlPath;
                Directory.CreateDirectory(Server.MapPath("~/Images/Profile"));
                var path = Path.Combine(Server.MapPath("~/Images/Profile/"), filename);
                file.SaveAs(path);
                if (userSql.setProfileUrl(user.UserID, urlPath))
                {
                    return Json(true);
                }
            }
            return Json(false);
        }
    }
}