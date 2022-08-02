﻿using projectapi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.Repository
{
    public interface IUserAccountRepo
    {
        List<UserAccountTable> ListAccounts();

        UserAccountTable CreateAccount(UserAccountTable model);

        UserAccountTable UpdateAccount(int id, UserAccountTable model);
        UserAccountTable Getaccount(int id);

        public UserLoan GetUserLoan(int id);

        List< UserAccountTable> GetAllAcc();

        public UserAccountTable GetUserLoanByAccount(string id);
        List<UserAccountTable> GetAllAccByStatus(string status);
    }
}
