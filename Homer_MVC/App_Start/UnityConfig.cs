using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using MySql.Data.MySqlClient;
using System.Collections.Specialized;
using System.Web.Mvc;
using Nigmys.Support;
using Homer_MVC.Controllers;

namespace Homer_MVC.App_Start
{
    public class UnityConfig
    {
        public static void ConfigureDependencies()
        {
            IUnityContainer container = new UnityContainer();

            ConfigureUserSQL(container);
            DependencyResolver.SetResolver(new NigmysDependencyResolver(container));
        }

        private static void ConfigureUserSQL(IUnityContainer container)
        {
            Configurations.SQLConfig config = (Configurations.SQLConfig)System.Configuration.ConfigurationManager.GetSection("sqlConfigurations/mySQLUserConfig");
            String connString = "server=" + config.Database.Address + ";userid=" + config.Database.Username + ";password=" + config.Database.Password 
                + ";database=" + config.Database.Name + ";";

            container.RegisterType<MySqlConnection>("UserConnect", new InjectionConstructor(connString));
            container.RegisterType<ISqlDatabase, SqlUserDatabase>("UserDB", new InjectionConstructor(new ResolvedParameter<MySqlConnection>("UserConnect")));
            container.RegisterType<IController, LoginController>(new InjectionConstructor(new ResolvedParameter<SqlUserDatabase>("UserDB")));
        }
    }
}