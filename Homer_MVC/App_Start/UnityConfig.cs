using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using MySql.Data.MySqlClient;
using System.Collections.Specialized;

namespace Homer_MVC.App_Start
{
    public class UnityConfig
    {
        public static void ConfigureDependencies()
        {
            IUnityContainer container = new UnityContainer();

            ConfigureUserSQL(container);
        }

        private static void ConfigureUserSQL(IUnityContainer container)
        {
            NameValueCollection section = (NameValueCollection)System.Configuration.ConfigurationManager.GetSection("mySQLUserConfig");
            container.RegisterType<MySqlConnection>();
            container.RegisterType<ISqlDatabase, SqlUserDatabase>("UserDB",
                new InjectionConstructor(
                    new ResolvedParameter<MySqlConnection>(),
                    section["server"],
                    section["username"],
                    section["password"],
                    section["database"]));
        }
    }
}