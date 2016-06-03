using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using MySql.Data.MySqlClient;
using System.Collections.Specialized;
using System.Web.Mvc;
using Nigmys.Support;
using Nigmys.Controllers;
using Nigmys.Services;
using Configurations;

namespace Nigmys.App_Start
{
    public class UnityConfig
    {
        /// <summary>
        /// Configure all dependency injection cases
        /// </summary>
        public static void ConfigureDependencies()
        {
            IUnityContainer container = new UnityContainer();

            /*SQL Configuration Strings*/
            String userConnString = UserSQLConnection();
            String portfolioConnString = PortfolioSQLConnection();
            String investmentInformationConnString = InvestmentInformationSQLConnection();

            /*Registrations*/

            /*MySQL Object Registrations*/
            RegisterUserDoa(container, userConnString);
            RegisterPortfolioDoa(container, portfolioConnString);
            RegisterInvestInformationDoa(container, investmentInformationConnString);

            /*Controller Registrations*/
            RegisterLoginController(container);
            RegisterSignUpController(container);
            RegisterInvestmentController(container);
            
            /*Resolve All Dependencies*/
            DependencyResolver.SetResolver(new NigmysDependencyResolver(container));
        }

        /// <summary>
        /// Creates configuration string needed when using data access object for the user sql database
        /// </summary>
        /// <returns>user configuration string</returns>
        private static String UserSQLConnection()
        {
            Configurations.SQLConfig userConfig = (Configurations.SQLConfig)System.Configuration.ConfigurationManager.GetSection("sqlConfigurations/mySQLUserConfig");
            String userConnString = "Server=" + userConfig.Database.Address + ";User=" + userConfig.Database.Username + ";Password=" + userConfig.Database.Password 
                + ";Database=" + userConfig.Database.Name + ";";

            return userConnString;
        }

        /// <summary>
        /// Creates configuration string needed when using data access object for the portfolio sql database
        /// </summary>
        /// <returns>portfolio configuration string</returns>
        private static String PortfolioSQLConnection()
        {
            Configurations.SQLConfig portfolioConfig = (Configurations.SQLConfig)System.Configuration.ConfigurationManager.GetSection("sqlConfigurations/mySQLPortfolioConfig");
            String portfolioConnString = "Server=" + portfolioConfig.Database.Address + ";User=" + portfolioConfig.Database.Username + ";Password=" + portfolioConfig.Database.Password
                + ";Database=" + portfolioConfig.Database.Name + ";";

            return portfolioConnString;
        }

        /// <summary>
        /// Creates configuration string needed when using data access object for the investment information sql database
        /// </summary>
        /// <returns>investment information configuration string</returns>
        private static String InvestmentInformationSQLConnection()
        {
            Configurations.SQLConfig investmentInformationConfig =
                (Configurations.SQLConfig)System.Configuration.ConfigurationManager.GetSection("sqlConfigurations/mySQLInvestmentInformationConfig");
            String investmentInformationConnString =
                "Server=" + investmentInformationConfig.Database.Address +
                ";User=" + investmentInformationConfig.Database.Username +
                ";Password=" + investmentInformationConfig.Database.Password +
                ";Database=" + investmentInformationConfig.Database.Name + ";";

            return investmentInformationConnString;
        }

        /// <summary>
        /// Register the connection string to create a user data access object dependency
        /// </summary>
        /// <param name="container">Container object used to resolve dependencies</param>
        /// <param name="userConnString">The user connection string for connecting to the user database</param>
        private static void RegisterUserDoa(IUnityContainer container, String userConnString)
        {
            container.RegisterType<MySqlConnection>("UserConnect", new InjectionConstructor(userConnString));
            container.RegisterType<ISqlUserDatabase, SqlUserDatabase>("UserDB",
                new InjectionConstructor(new ResolvedParameter<MySqlConnection>("UserConnect")));
        }

        /// <summary>
        /// Register the portfolio connection string to create portfolio data access object dependency
        /// </summary>
        /// <param name="container">Container object used to resolve dependencies</param>
        /// <param name="portfolioConnString">The portfolio connection string for connecting to the portfolio database</param>
        private static void RegisterPortfolioDoa(IUnityContainer container, String portfolioConnString)
        {
            container.RegisterType<MySqlConnection>("PortfolioConnect", new InjectionConstructor(portfolioConnString));
            container.RegisterType<ISqlPortfolioDatabase, SqlPortfolioDatabase>("PortfolioDB",
                new InjectionConstructor(new ResolvedParameter<MySqlConnection>("PortfolioConnect")));
        }

        /// <summary>
        /// Register the investment information connection string to create investment information data access object dependency 
        /// </summary>
        /// <param name="container">Container object used to resolve dependencies</param>
        /// <param name="investmentInformationConnString">Connection string used for connecting to the investment information database</param>
        private static void RegisterInvestInformationDoa(IUnityContainer container, String investmentInformationConnString)
        {
            container.RegisterType<MySqlConnection>("InvestmentInformationConnect", new InjectionConstructor(investmentInformationConnString));
            container.RegisterType<ISqlInvestmentInformationDatabase, SqlInvestmentInformationDatabase>("InvestmentInformationDB",
                new InjectionConstructor(new ResolvedParameter<MySqlConnection>("InvestmentInformationConnect")));
        }

        /// <summary>
        /// Register the login controller with the proper objects
        /// </summary>
        /// <param name="container">Container object used to resolve dependencies</param>
        private static void RegisterLoginController(IUnityContainer container)
        {
            container.RegisterType<IController, LoginController>(new InjectionConstructor(
                new ResolvedParameter<SqlUserDatabase>("UserDB")));
        }

        /// <summary>
        /// Register the sign up controller with the proper objects
        /// </summary>
        /// <param name="container">Container object used to resolve dependencies</param>
        private static void RegisterSignUpController(IUnityContainer container)
        {
            container.RegisterType<IController, SignUpController>(new InjectionConstructor(
                new ResolvedParameter<SqlUserDatabase>("UserDB"),
                new ResolvedParameter<SqlPortfolioDatabase>("PortfolioDB")
                ));
        }

        /// <summary>
        /// Register the investment controller with the proper objects
        /// </summary>
        /// <param name="container">Container object used to resolve dependencies</param>
        private static void RegisterInvestmentController(IUnityContainer container)
        {
            container.RegisterType<IController, InvestmentsController>(new InjectionConstructor(
                new ResolvedParameter<SqlInvestmentInformationDatabase>("InvestmentInformationDB"),
                new ResolvedParameter<SqlPortfolioDatabase>("PortfolioDB")
                ));
        }
    }
}