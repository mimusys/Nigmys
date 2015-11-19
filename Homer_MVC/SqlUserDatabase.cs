using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Homer_MVC {
    public class SqlUserDatabase : ISqlUserDatabase {
        private MySqlConnection conn = null;

        // setup our SQL connection.  For testing locally, sane values would be 127.0.0.1, root, "", <database name>
        public void Connect(String server, String user, String password, String database) {
            conn = new MySqlConnection();

            String connString = "server="+ server + ";uid=" + user + ";database=" + database + ";";
            conn.ConnectionString = connString;
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

        // retrieve all the data for our users
        public List<string>[] getUsers() {
            if (Open()) {
                List<string>[] list = new List<string>[11];
                for (int i = 0; i < 11; ++i) {
                    list[i] = new List<string>();
                }

                MySqlCommand cmd = new MySqlCommand("select * from users;", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    list[0].Add(reader["customerID"] + "");
                    list[1].Add(reader["username"] + "");
                    list[2].Add(reader["firstname"] + "");
                    list[3].Add(reader["lastname"] + "");
                    list[4].Add(reader["passwordID"] + "");
                    list[5].Add(reader["address"] + "");
                    list[6].Add(reader["zip"] + "");
                    list[7].Add(reader["email"] + "");
                    list[8].Add(reader["birthdate"] + "");
                    list[9].Add(reader["companyName"] + "");
                    list[10].Add(reader["pictureUrl"] + "");
                }

                reader.Close();
                Close();
                return list;
            }
            return null;
        }

        // given a user's username or email address, retrieve the applicable password information
        public String[] getPasswordInfo(String usernameOrEmail) {
            if (Open()) {
                String[] passwordInfo = null;  // keep null until we're sure we have info to return

                // select passwordInfo for a given username or email
                MySqlCommand cmd = new MySqlCommand("select P.passwordHash, P.salt from passwordInformation P, Users U where (U.username ='" +
                    usernameOrEmail + "' or U.email = '" + usernameOrEmail + "') and P.passwordID = U.passwordID;", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                // if Read() returns false we have no record of the username or email
                if (reader.Read()) {
                    // we know we have password information so let's construct our array
                    // and put the info into the string array
                    passwordInfo = new String[2];
                    passwordInfo[0] = reader["passwordHash"] + "";
                    passwordInfo[1] = reader["salt"] + "";
                }

                reader.Close();
                Close();
                return passwordInfo;
            }
            return null;
        }

        public bool addNewUser(String username, String firstName, String lastName, String passwordHash, String passwordSalt,
                String address, String zip, String email, int bdayMonth, int bdayDay, int bdayYear, String company, String pictureUrl) {
            if (Open()) {
                // first we insert the password information so we have a passwordID key to insert into users table
                // "select SCOPE_IDENTITY() makes it return the first row which was updated, in this case the new
                // password row
                MySqlCommand cmd = new MySqlCommand("insert into passwordInformation(passwordHash, salt) VALUES ('" + passwordHash + "', '" + 
                        passwordSalt + "'); select LAST_INSERT_ID();", conn);
                object passwordIdRet = cmd.ExecuteScalar();
                if (passwordIdRet != null) {
                    int passwordID = Convert.ToInt32(passwordIdRet);
                    // construct our insert statement
                    String query = "insert into users(username, firstName, lastName, passwordID, address, zip, email, birthdate, companyName, pictureUrl) VALUES ";
                    query += "('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', {7}-{8}-{9}, '{10}', '{11}');";
                    query = string.Format(query, username, firstName, lastName, passwordID, address, zip, email, bdayYear, bdayMonth, bdayDay, company, pictureUrl);
                    cmd.CommandText = query;

                    // ExecuteNonQuery returns numbers of rows affected, in this case should be 1
                    int ret = cmd.ExecuteNonQuery();
                    Close();

                    return (ret == 1);  // 1 row affected == success
                } else {
                    // failed to insert password for some reason
                    Close();
                    return false;
                }
            } else return false;
        }
    }
}