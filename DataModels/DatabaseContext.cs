using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.DataModels
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<DocumentDetails> DocumentDetails { get; set; }
        public DbSet<IncomeDetails> IncomeDetails { get; set; }
        
        public DbSet<LoanDetails> LoanDetails { get; set; }
        public DbSet<UserLoan> UserLoan { get; set; }
        public DbSet<UserTable> UserTable { get; set; }
        public DbSet<UserBankDetails> UserBankDetails { get; set; }
        public DbSet<UserAccountTable> UserAccountTable { get; set; }

    }
}
