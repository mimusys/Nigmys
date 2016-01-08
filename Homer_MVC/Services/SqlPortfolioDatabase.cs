﻿using System;
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

        public void deletePortfolioID(int id) {
            if (Open()) {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM portfolio WHERE portfolioID = @portfolioID", conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@portfolioID", id);

                cmd.ExecuteNonQuery();
                Close();
            }
        }
    }
}