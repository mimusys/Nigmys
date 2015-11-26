using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homer_MVC {
    public interface ISqlUserDatabase : ISqlDatabase {

        String[] getPasswordInfo(String usernameOrEmail);

        bool addNewUser(String username, String firstName, String lastName, String passwordHash, String passwordSalt,
            String address, String zip, String email, int bdayMonth, int bdayDay, int bdayYear, String company, String pictureUrl);

        bool doesUsernameExist(String username);

        bool doesEmailExist(String email);

        String generateSalt();
    }
}