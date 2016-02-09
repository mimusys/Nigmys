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
using Homer_MVC.Services;

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
            Configurations.SQLConfig userConfig = (Configurations.SQLConfig)System.Configuration.ConfigurationManager.GetSection("sqlConfigurations/mySQLUserConfig");
            String userConnString = "Server=" + userConfig.Database.Address + ";User=" + userConfig.Database.Username + ";Password=" + userConfig.Database.Password 
                + ";Database=" + userConfig.Database.Name + ";";

            Configurations.SQLConfig portfolioConfig = (Configurations.SQLConfig)System.Configuration.ConfigurationManager.GetSection("sqlConfigurations/mySQLPortfolioConfig");
            String portfolioConnString = "Server=" + portfolioConfig.Database.Address + ";User=" + portfolioConfig.Database.Username + ";Password=" + portfolioConfig.Database.Password
                + ";Database=" + portfolioConfig.Database.Name + ";";

            Configurations.SQLConfig investmentInformationConfig = 
                (Configurations.SQLConfig)System.Configuration.ConfigurationManager.GetSection("sqlConfigurations/mySQLInvestmentInformationConfig");
            String investmentInformationConnString = 
                "Server=" + investmentInformationConfig.Database.Address + 
                ";User=" + investmentInformationConfig.Database.Username + 
                ";Password=" + investmentInformationConfig.Database.Password +
                ";Database=" + investmentInformationConfig.Database.Name + ";";

            container.RegisterType<MySqlConnection>("UserConnect", new InjectionConstructor(userConnString));
            container.RegisterType<ISqlUserDatabase, SqlUserDatabase>("UserDB", 
                new InjectionConstructor(new ResolvedParameter<MySqlConnection>("UserConnect")));

            container.RegisterType<MySqlConnection>("PortfolioConnect", new InjectionConstructor(portfolioConnString));
            container.RegisterType<ISqlPortfolioDatabase, SqlPortfolioDatabase>("PortfolioDB", 
                new InjectionConstructor(new ResolvedParameter<MySqlConnection>("PortfolioConnect")));

            container.RegisterType<MySqlConnection>("InvestmentInformationConnect", new InjectionConstructor(investmentInformationConnString));
            container.RegisterType<ISqlInvestmentInformationDatabase, SqlInvestmentInformationDatabase>("InvestmentInformationDB", 
                new InjectionConstructor(new ResolvedParameter<MySqlConnection>("InvestmentInformationConnect")));

            container.RegisterType<IController, LoginController>(new InjectionConstructor(new ResolvedParameter<SqlUserDatabase>("UserDB")));

            container.RegisterType<IController, SignUpController>(new InjectionConstructor(
                new ResolvedParameter<SqlUserDatabase>("UserDB"),
                new ResolvedParameter<SqlPortfolioDatabase>("PortfolioDB")
                ));

            container.RegisterType<IController, InvestmentsController>(new InjectionConstructor(
                new ResolvedParameter<SqlInvestmentInformationDatabase>("InvestmentInformationDB"),
                new ResolvedParameter<SqlPortfolioDatabase>("PortfolioDB")
                ));
        }
    }
}