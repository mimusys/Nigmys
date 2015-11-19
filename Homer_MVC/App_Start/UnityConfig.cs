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
            Configurations.SQLConfig config = (Configurations.SQLConfig)System.Configuration.ConfigurationManager.GetSection("sqlConfigurations/mySQLUserConfig");
            container.RegisterType<MySqlConnection>();
            container.RegisterType<ISqlDatabase, SqlUserDatabase>("UserDB",
                new InjectionConstructor(
                    new ResolvedParameter<MySqlConnection>(),
                    config.Database.Address,
                    config.Database.Username,
                    config.Database.Password,
                    config.Database.Name));
        }
    }
}