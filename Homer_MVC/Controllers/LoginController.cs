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
            System.Diagnostics.Debug.WriteLine("Loading page");
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(string username, string password)
        {
            System.Diagnostics.Debug.WriteLine("Checking Login");

            
            List<string> userNameList = userSql.getUserNames();
            String message = "";
            if (userNameList == null)
            {
                System.Diagnostics.Debug.WriteLine("No users in the list!");
                message = "No users in the list!";
                return null;
            }
            
            message = "Users Exists";
            if (userNameList.Contains(username))
            {
                System.Diagnostics.Debug.WriteLine("Login was Successful!");
                String[] dbPass = userSql.getPasswordInfo(username);
                String salt = dbPass[1];
                String hash = dbPass[0];


                //Figure out the salt/hash system and compare it to the 'password' parameter
                //If password == password in db,
                //Redirect to Dashboard  
                //@Url.Action("Index", "SignUp")


            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Login was NOT Successful!");
            }
            
            return Json(new { Message = message, Username = username, Password = password });

        }

    }
}
