using Nigmys.Models;
using System;

namespace Nigmys
{
    public interface ISqlUserDatabase : ISqlDatabase {

        /// <summary>
        /// Retrieve all the data for our users
        /// </summary>
        /// <param name="usernameOrEmail">get password from email or username</param>
        /// <returns>Password info or null</returns>
        String[] getPasswordInfo(String usernameOrEmail);

        /// <summary>
        /// Construct User from SQL data
        /// </summary>
        /// <param name="usernameOrEmail">username/email in check</param>
        /// <returns>Returns user object</returns>
        User getUser(String usernameOrEmail);

        /// <summary>
        /// Create a new user for both local and stripe databases.  First we insert the password 
        /// information so we have a passwordID key to insert into users table 
        /// select LAST_INSERT_ID() makes it return the first row which was updated, 
        /// in this case the new password row
        /// </summary>
        /// <param name="user">The user being added to the database</param>
        /// <returns></returns>
        int addNewUser(User user);

        /// <summary>
        /// This method is responsible for creating a timestamp for trial accounts
        /// </summary>
        /// <param name="customerId">The customer's ID for who we are creating the trial account for</param>
        /// <returns>Date when trial was created</returns>
        String createTrialAccount(String customerId);

        /// <summary>
        /// Delete the trial account due to the account changing status
        /// </summary>
        /// <param name="customerId"> The customer's id for whom we are changing for</param>
        /// <returns>Return successful/failed operation</returns>
        bool deleteTrialAccount(String customerId);

        /// <summary>
        /// Sets the user's profile picture if available
        /// </summary>
        /// <param name="userId">customer's unique id</param>
        /// <param name="url">url of profile picture</param>
        /// <returns>Returns if successful/failed</returns>
        bool setProfileUrl(String userId, String url);

        /// <summary>
        /// Given a user's username or email address, retrieve the 
        /// applicable password information
        /// </summary>
        /// <param name="username">username in test</param>
        /// <returns>Return's true if username exists</returns>
        bool doesUsernameExist(String username);

        /// <summary>
        /// Checks if email exists in database
        /// </summary>
        /// <param name="email">the email in check</param>
        /// <returns>return true if email exists in database, false otherwise</returns>
        bool doesEmailExist(String email);
    }
}