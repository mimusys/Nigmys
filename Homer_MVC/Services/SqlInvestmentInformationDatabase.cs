using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homer_MVC.Services {
    public class SqlInvestmentInformationDatabase : SqlDatabase, ISqlInvestmentInformationDatabase  {
        public SqlInvestmentInformationDatabase(MySqlConnection conn) : base(conn) {

        }
    }
}