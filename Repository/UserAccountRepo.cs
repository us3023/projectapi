using Microsoft.Extensions.Options;
using projectapi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.Repository
{
    public class UserAccountRepo : IUserAccountRepo
    {

        private readonly DatabaseContext _db;
        private readonly AppSettings _appSettings;

        public UserAccountRepo(DatabaseContext db, IOptions<AppSettings> appsettings)
        {
            _db = db;
            _appSettings = appsettings.Value;
        }

        UserAccountTable IUserAccountRepo.CreateAccount(UserAccountTable model)
        {
            _db.UserAccountTable.Add(model);

            _db.SaveChanges();

            return model;
        }

        List<UserAccountTable> IUserAccountRepo.ListAccounts()
        {
            throw new NotImplementedException();
        }

        UserAccountTable IUserAccountRepo.UpdateAccount(int id, UserAccountTable model)
        {
            throw new NotImplementedException();
        }
    }
}
