using projectapi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.Repository
{
    public interface IUserTableRepo
    {
        bool IsUniqueUser(string username);
        UserTable Authenticate(string username, string password);
        UserTable Register(string username, string password);
    }
}
