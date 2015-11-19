using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homer_MVC {
    interface ISqlUserDatabase {
        void Connect(String server, String user, String password, String database);

        bool Open();

        bool Close();

        List<string>[] getUsers();

        String[] getPasswordInfo(String usernameOrEmail);

        bool addNewUser(String username, String firstName, String lastName, String passwordHash, String passwordSalt,
               String address, String zip, String email, int bdayMonth, int bdayDay, int bdayYear, String company, String pictureUrl);

    }
}
