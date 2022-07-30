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
        private readonly DatabaseContext context;
        public Repos(DatabaseContext context)
        {
            this.context = context;
        }

       

        public List<UserAccountTable> GetData()
        {
            // return context.Student.ToList();
              return context.UserAccountTable.Include("UserTable").Include("UserLoan").ToList();
           // return context.UserAccountTable.ToList();
        }
    }
}
