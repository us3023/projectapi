using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.DataModels
{
    public class UserLoan
    {
        public int ID { get; set; }

        public int Amount { get; set; }
        public DateTime Due_Date { get; set; }
        public DateTime Next_Due_Date { get; set; }
        public int Remaining_Amount { get; set; }
        public DateTime Date_Sanctioned { get; set; }
        // navigation loandetails , userbank, incomedetails , doc details
        public LoanDetails LoanDetails { get; set; }
        public UserBankDetails UserBank { get; set; }
        public IncomeDetails IncomeDetails { get; set; }        public DocumentDetails DocumentDetails { get; set; }        public UserTable UserDetails { get; set; }    }
}
