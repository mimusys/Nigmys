using Nigmys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nigmys {
    public interface ISqlUserDatabase : ISqlDatabase {

        String[] getPasswordInfo(String usernameOrEmail);

        User getUser(String usernameOrEmail);

        int addNewUser(User user);

        /// <summary>
        /// This method is responsible for creating a timestamp for trial accounts
        /// </summary>
        /// <param name="customerId">The customer's ID for who we are creating the trial account for</param>
        /// <returns></returns>
        String createTrialAccount(String customerId);

        /// <summary>
        /// Delete the trial account due to the account changing status
        /// </summary>
        /// <param name="customerId"> The customer's id for whom we are changing for</param>
        /// <returns></returns>
        bool deleteTrialAccount(String customerId);

        bool setProfileUrl(String userId, String url);

        bool doesUsernameExist(String username);

        bool doesEmailExist(String email);
    }
}