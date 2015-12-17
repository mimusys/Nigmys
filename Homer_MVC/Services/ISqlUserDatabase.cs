using Homer_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homer_MVC {
    public interface ISqlUserDatabase : ISqlDatabase {

        String[] getPasswordInfo(String usernameOrEmail);

        int addNewUser(User user);

        bool setProfileUrl(String userId, String url);

        bool doesUsernameExist(String username);

        bool doesEmailExist(String email);
    }
}