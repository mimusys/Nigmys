﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Homer_MVC.Services {
    public class SqlUserDatabase : SqlDatabase, ISqlUserDatabase {
        private Random rnd = new Random();
        
        public SqlUserDatabase(MySqlConnection conn) : base(conn) {

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
        // return null if username/email does not exist
        public String[] getPasswordInfo(String usernameOrEmail) {
            if (Open()) {
                String[] passwordInfo = null;  // keep null until we're sure we have info to return

                // select passwordInfo for a given username or email
                //MySqlCommand cmd = new MySqlCommand("select P.passwordHash, P.salt from passwordInformation P, Users U where (U.username ='" +
                //    usernameOrEmail + "' or U.email = '" + usernameOrEmail + "') and P.passwordID = U.passwordID;", conn);

                MySqlCommand cmd = new MySqlCommand("select P.passwordHash, P.salt from passwordInformation P, Users U where (U.username = @username" +
                    " or U.email = @email) and P.passwordID = U.passwordID;", conn);
                cmd.Parameters.AddWithValue("@username", usernameOrEmail);
                cmd.Parameters.AddWithValue("@email", usernameOrEmail);
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
                // "select LAST_INSERT_ID() makes it return the first row which was updated, in this case the new
                // password row
                //MySqlCommand cmd = new MySqlCommand("insert into passwordInformation(passwordHash, salt) VALUES ('" + passwordHash + "', '" + 
                //        passwordSalt + "'); select LAST_INSERT_ID();", conn);

                MySqlCommand cmd = new MySqlCommand("insert into passwordInformation(passwordHash, salt) VALUES (@passwordHash, @passwordSalt); " +
                    "select LAST_INSERT_ID();", conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                cmd.Parameters.AddWithValue("@passwordSalt", passwordSalt);

                object passwordIdRet = cmd.ExecuteScalar();
                if (passwordIdRet != null) {
                    int passwordID = Convert.ToInt32(passwordIdRet);
                    DateTime bday = new DateTime(bdayYear, bdayMonth, bdayDay);
                    // construct our insert statement
                    String query = "insert into users(username, firstName, lastName, passwordID, address, zip, email, birthdate, companyName, pictureUrl) VALUES ";
                    query += "(@username, @firstName, @lastName, @passwordID, @address, @zip, @email, @birthday, @companyName, @pictureUrl);";
                    //query += "('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', {7}-{8}-{9}, '{10}', '{11}');";
                    //query = string.Format(query, username, firstName, lastName, passwordID, address, zip, email, bdayYear, bdayMonth, bdayDay, company, pictureUrl);
                    cmd.CommandText = query;
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@passwordID", passwordID);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@zip", zip);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@birthday", bday);
                    cmd.Parameters.AddWithValue("@companyName", company);
                    cmd.Parameters.AddWithValue("@pictureUrl", pictureUrl);

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

        public bool doesUsernameExist(String username) {
            return false;
        }

        public bool doesEmailExist(String email) {
            return false;
        }

        public string generateSalt() {
            int salt = rnd.Next(1000, 9999);
            return salt.ToString();
        }
    }
}