using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homer_MVC.Services {
    public class SqlDatabase : ISqlDatabase {
        protected MySqlConnection conn;

        public SqlDatabase(MySqlConnection conn) {
            this.conn = conn;
        }

        // open the connection if not already open
        public bool Open() {
            if (conn != null && conn.State != System.Data.ConnectionState.Open) {
                try {
                    // connection state could also be Broken, Connecting, Executing, Fetching
                    // close then open negates that
                    conn.Close();
                    conn.Open();
                    return true;
                } catch (MySqlException ex) {
                    System.Diagnostics.Trace.WriteLine("Error: failed to connect to database");
                    return false;
                }
            }
            return false;
        }

        // close connection if not already closed
        public bool Close() {
            if (conn != null && conn.State != System.Data.ConnectionState.Closed) {
                conn.Close();
                return true;
            }
            return false;
        }

        public string GetConnString() {
            return conn.ConnectionString;
        }
    }
}