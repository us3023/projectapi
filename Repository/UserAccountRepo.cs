using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using projectapi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.Repository
{
    /**
     * UserAccountRepo inherits from IUserAccountRepo
     */
    public class UserAccountRepo : IUserAccountRepo
    {

        /**
         * Dependency Injection for Db Context and for appsettings 
         */

        private readonly DatabaseContext _db;
        private readonly AppSettings _appSettings;

        public UserAccountRepo(DatabaseContext db, IOptions<AppSettings> appsettings)
        {
            _db = db;
            _appSettings = appsettings.Value;
        }

        /**
         * @params model of type UserAccountTable
         * Creating a User account
         * @return model 
         */
        UserAccountTable IUserAccountRepo.CreateAccount(UserAccountTable model)
        {
            _db.UserAccountTable.Add(model);

            _db.SaveChanges();

            return model;
        }

        /**
         * @params id 
         * getting a User account
         * @return datamodel of type UserAccountTable
         */

        UserAccountTable IUserAccountRepo.Getaccount(int id)
        {
            var res = _db.UserAccountTable
                .Include("UserLoan")
                .Include("UserTable")
                .FirstOrDefault(x => x.ID == id);

            res.UserLoan = GetUserLoan(res.UserLoan.ID);

            return res;
        }
        /**
        * getting All Accounts
        * @return datamodel of type UserAccountTable
        */

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


        /**
        * @params id and model of type UserAccountTable
        * Updating the account
        * @return existing account model  of type UserAccountTable
        */
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

        /**
        * @params id 
        * getting UserLoan
        * @return datamodel of type UserLoan
        */

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

        /**
        * @params id 
        * getting a User Loan by account 
        * @return datamodel of type UserAccountTable
        */

        public UserAccountTable GetUserLoanByAccount(string id)
        {
            return _db.UserAccountTable.Where(x => x.Account_ID == id).FirstOrDefault();
        }

        /**
        * @params status  
        * getting all the accounts using status
        * @return list of type UserAccountTable
        */

        public List<UserAccountTable> GetAllAccByStatus(string status)
        {
            var result = _db.UserAccountTable
                .Include("UserLoan")
                .Include("UserTable")
                .Where(x => x.Status == status).ToList();

            foreach (var res in result)
            {
                res.UserLoan = GetUserLoan(res.UserLoan.ID);
            }

            return result;
        }

     
    }
}
