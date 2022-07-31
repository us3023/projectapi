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
        UserAccountTable IUserAccountRepo.Getaccount(int id)
        {
            return _db.UserAccountTable.FirstOrDefault(x => x.ID == id);
        }
        public List<UserAccountTable> GetAllAcc()
        {
            var accs = _db.UserAccountTable.ToList();
            return accs;
        }
        List<UserAccountTable> IUserAccountRepo.ListAccounts()
        {
            throw new NotImplementedException();
        }



        UserAccountTable IUserAccountRepo.UpdateAccount(int id, UserAccountTable model)
        {
            var existingAcc = _db.UserAccountTable.FirstOrDefault(x => x.ID == id);
            if (existingAcc == null)
            {
                return null;
            }
            existingAcc.Account_ID = model.Account_ID;
            existingAcc.Status = model.Status;
            existingAcc.Signature = model.Signature;
            existingAcc.UserTable= model.UserTable;
            existingAcc.UserLoan = model.UserLoan;
            _db.SaveChanges();
            return existingAcc;
        }
    }
}
