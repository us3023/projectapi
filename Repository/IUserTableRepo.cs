using projectapi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.Repository
{

    /**
    * INTERFACE IUserTableRepo ( Repository )
    */
    public interface IUserTableRepo
    {
        UserTable Authenticate(string username, string password);
        UserTable CreateUser(UserTable user);

        List<UserTable> GetAllUsers();

        UserTable GetUser(int id);

        bool AddUser(UserTable userTable);

        UserTable UpdateUser(int id, UserTable userTable);

        UserTable DeleteUser(int id);
    }
}
