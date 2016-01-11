using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Homer_MVC.Services {
    public class SqlPortfolioDatabase : SqlDatabase, ISqlPortfolioDatabase {

        public SqlPortfolioDatabase(MySqlConnection conn) : base(conn) {
        }

        public int createNewPortfolioID() {
            int portfolioID = -1;
            if (Open()) {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO portfolio VALUES (null); select LAST_INSERT_ID();", conn);
                cmd.Prepare();

                object portfolioIDObj = cmd.ExecuteScalar();
                if (portfolioIDObj != null) {
                    portfolioID = Convert.ToInt32(portfolioIDObj);
                }

                Close();
            }
            return portfolioID;
        }

        public bool deletePortfolioID(int id) {
            bool success = false;
            if (Open()) {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM portfolio WHERE portfolioID = @portfolioID", conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@portfolioID", id);

                success = (cmd.ExecuteNonQuery() == 1);
                Close();
            }
            return success;
        }

        public bool addInvestmentID(int portfolioID, int investmentID) {
            bool success = false;
            if (Open()) {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO portfolioInvestmentInformation (investmentInformationID, portfolioID) " + 
                    "VALUES (@investmentInformationID, @portfolioID);", conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@investmentInformationID", investmentID);
                cmd.Parameters.AddWithValue("@portfolioID", portfolioID);

                if (cmd.ExecuteNonQuery() == 1) {
                    success = true;
                }
            }
            return success;
        }
    }
}