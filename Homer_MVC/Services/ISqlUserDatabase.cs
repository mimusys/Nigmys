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

        bool setProfileUrl(String userId, String url);

        bool doesUsernameExist(String username);

        bool doesEmailExist(String email);
    }
}