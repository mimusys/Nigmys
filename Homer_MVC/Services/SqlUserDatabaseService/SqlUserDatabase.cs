using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Nigmys.Models;
using Nigmys.Services.StripeAccessorService;
using Stripe;


namespace Nigmys.Services {
    public class SqlUserDatabase : SqlDatabase, ISqlUserDatabase {
        private Random rnd = new Random();
        IStripeAccessorService stripeAccessor;
        
        public SqlUserDatabase(MySqlConnection conn, StripeAccessorService.StripeAccessorService stripeAccessor) : base(conn) {
            this.stripeAccessor = stripeAccessor;
        }

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
 
        public User getUser(String usernameOrEmail) {
            User user = null;
            if (Open()) {
                MySqlCommand cmd = new MySqlCommand("select * from users U where (U.username = @username or U.email = @email);", conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@username", usernameOrEmail);
                cmd.Parameters.AddWithValue("@email", usernameOrEmail);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    StripeObject stripeObj = stripeAccessor.GetCustomer((string)reader["stripeID"]);
                    if (stripeObj is StripeCustomer)
                    {
                        StripeCustomer customerObj = (StripeCustomer)stripeObj;
                        user = new User();
                        user.UserID = reader["customerID"] + "";
                        user.Username = reader["username"] + "";
                        user.FirstName = reader["firstName"] + "";
                        user.LastName = reader["lastName"] + "";
                        user.Email = reader["email"] + "";
                        user.Address = reader["address"] + "";
                        user.Zipcode = reader["zip"] + "";
                        user.CompanyName = reader["companyName"] + "";
                        user.PictureURL = reader["pictureURL"] + "";
                        user.Birthday = DateTime.Parse(reader["birthDate"] + "");
                        user.stripeId = reader["stripeID"] + "";
                        user.stripeObject = customerObj;
                        user.PortfolioID = Convert.ToInt32(reader["portfolioID"]);
                    }

                    
                }
                reader.Close();

                Close();
            }
            return user;
        }

        public String[] getPasswordInfo(String usernameOrEmail) {
            if (Open()) {
                String[] passwordInfo = null;  // keep null until we're sure we have info to return

                // select passwordInfo for a given username or email
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
  
        public int addNewUser(User user) { 

            int userId = -1;

            if (Open()) {

                MySqlCommand cmd = new MySqlCommand("insert into passwordInformation(passwordHash, salt) VALUES (@passwordHash, @passwordSalt); " +
                    "select LAST_INSERT_ID();", conn);

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@passwordSalt", user.Salt);

                object passwordIdRet = cmd.ExecuteScalar();

                if (passwordIdRet != null) {
                    if (user.CompanyName == null) {
                        user.CompanyName = "None";
                    }

                    int passwordID = Convert.ToInt32(passwordIdRet);

                    /*Stripe Creation*/
                    StripeObject accessorReturn = stripeAccessor.CreateCustomer(user.Email, user.FirstName, user.LastName);

                    if (accessorReturn is StripeCustomer)
                    {
                        StripeCustomer createdCustomer = (StripeCustomer)accessorReturn;

                        /*Construct Insert Statement*/
                        String query = "insert into users(stripeID, username, firstName, lastName, passwordID, address, zip, email, birthdate, companyName, portfolioID, status) VALUES ";
                        query += "(@stripeID, @username, @firstName, @lastName, @passwordID, @address, @zip, @email, @birthday, @companyName, @portfolioID, @status); select LAST_INSERT_ID();";

                        cmd.CommandText = query;
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@stripeID", createdCustomer.Id);
                        cmd.Parameters.AddWithValue("@username", user.Username);
                        cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@lastName", user.LastName);
                        cmd.Parameters.AddWithValue("@passwordID", passwordID);
                        cmd.Parameters.AddWithValue("@address", user.Address);
                        cmd.Parameters.AddWithValue("@zip", user.Zipcode);
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@birthday", user.Birthday);
                        cmd.Parameters.AddWithValue("@companyName", user.CompanyName);
                        cmd.Parameters.AddWithValue("@portfolioID", user.PortfolioID);
                        cmd.Parameters.AddWithValue("@status", status.freeTrial);

                        /*Execute Scalar returns the id of the user added, null otherwise*/
                        object userIdRet = cmd.ExecuteScalar();
                        Close();

                        user.stripeObject = createdCustomer;

                        if (userIdRet != null)
                        {
                            userId = Convert.ToInt32(userIdRet);
                        }
                    }
                } else {
                    /*Failed to Insert Password*/
                    Close();
                }
            }
            return userId;
        }

        public bool setProfileUrl(String userId, String url) {
            bool success = false;

            if (Open()) {
                MySqlCommand cmd = new MySqlCommand("UPDATE users SET pictureUrl = @url WHERE customerID = @customerID", conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@url", url);
                cmd.Parameters.AddWithValue("@customerID", userId);

                int ret = cmd.ExecuteNonQuery();
                success = (ret == 1);
                Close();
            }
            return success;
        }

        public bool doesUsernameExist(String username) {
            if (Open()) {
                MySqlCommand cmd = new MySqlCommand("select count(*) from users U where U.username = @username;", conn);
                cmd.Parameters.AddWithValue("@username", username);
                int num = Convert.ToInt32(cmd.ExecuteScalar());
                Close();

                /*If 0 username does not exist*/
                return num != 0; 
            }
            return true;
        }

        public bool doesEmailExist(String email) {
            if (Open()) {
                MySqlCommand cmd = new MySqlCommand("select count(*) from users U where U.email = @email;", conn);
                cmd.Parameters.AddWithValue("@email", email);
                int num = Convert.ToInt32(cmd.ExecuteScalar());
                Close();

                /*If 0 email does not exist*/
                return num != 0; 
            }
            return true;
        }

        public String createTrialAccount(String customerId)
        {
            if(Open())
            {
                MySqlCommand cmd = new MySqlCommand("insert into trialaccounts(customerID, date) VALUES (@customerID, @date);" + 
                    "select LAST_INSERT_ID();", conn);

                String today = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@customerID", customerId);
                cmd.Parameters.AddWithValue("@date", today);
                cmd.ExecuteScalar();

                return today;    
            }

            return null;
        }

        public bool deleteTrialAccount(String customerId)
        {
            bool success = false;
            if (Open())
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM trialaccounts WHERE customerID = @customerID", conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@customerID", customerId);

                success = (cmd.ExecuteNonQuery() == 1);
                Close();
            }
            return success;
        }
    }
}