using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using System.Data.Odbc;
using System.Collections.Specialized;
using System.Web.Mvc;
using Nigmys.Support;
using Homer_MVC.Controllers;
using Homer_MVC.Services;

namespace Homer_MVC.App_Start
{
    public class UnityConfig
    {
        static String driver = "Driver={MySQL ODBC 5.3 Unicode Driver};";
        static String option = "Option=3;";
        public static void ConfigureDependencies()
        {
            IUnityContainer container = new UnityContainer();

            ConfigureUserSQL(container);
            DependencyResolver.SetResolver(new NigmysDependencyResolver(container));
        }

        private static void ConfigureUserSQL(IUnityContainer container)
        {
            Configurations.SQLConfig config = (Configurations.SQLConfig)System.Configuration.ConfigurationManager.GetSection("sqlConfigurations/mySQLUserConfig");
            String connString = driver+"Server=" + config.Database.Address + ";User=" + config.Database.Username + ";Password=" + config.Database.Password 
                + ";Database=" + config.Database.Name + ";"+option;
            
            container.RegisterType<OdbcConnection>("UserConnect", new InjectionConstructor(connString));
            container.RegisterType<ISqlUserDatabase, SqlUserDatabase>("UserDB", new InjectionConstructor(new ResolvedParameter<OdbcConnection>("UserConnect")));
            container.RegisterType<IController, LoginController>(new InjectionConstructor(new ResolvedParameter<SqlUserDatabase>("UserDB")));
        }
    }
}