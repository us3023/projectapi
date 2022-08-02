using Microsoft.EntityFrameworkCore;
using projectapi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.Repository
{
    public class Repos : IRepos
    {
        /**
         * Dependency Injection for using DbContext 
         */

        private readonly DatabaseContext context;
        public Repos(DatabaseContext context)
        {
            this.context = context;
        }

        /**
         * Getting the Data of user userAccount table 
         * including userTable , UserLoan 
         */
       

        public List<UserAccountTable> GetData()
        {
           
              return context.UserAccountTable.Include("UserTable").Include("UserLoan").ToList();
           
        }
    }
}
