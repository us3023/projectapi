using Microsoft.EntityFrameworkCore;
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
            var res = _db.UserAccountTable
                .Include("UserLoan")
                .Include("UserTable")
                .FirstOrDefault(x => x.ID == id);

            res.UserLoan = GetUserLoan(res.UserLoan.ID);

            return res;
        }
        public List<UserAccountTable> GetAllAcc()
        {
            var result = _db.UserAccountTable.Include("UserLoan")
                .Include("UserTable").ToList();

            foreach(var res in result)
            {
                res.UserLoan = GetUserLoan(res.UserLoan.ID);
            }

            return result;
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

        public UserLoan GetUserLoan(int id)
        {
            return _db.UserLoan
                 .Include("LoanDetails")
                 .Include("UserBank")
                 .Include("IncomeDetails")
                 .Include("DocumentDetails")
                 .Include("UserDetails")
                 .Where(x => x.ID == id).FirstOrDefault();
        }

        public UserAccountTable GetUserLoanByAccount(string id)
        {
            return _db.UserAccountTable.Where(x => x.Account_ID == id).FirstOrDefault();
        }

    }
}
