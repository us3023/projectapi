using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.DataModels
{
    public class LoanDetails
    {
        public long Amount_Required { get; set; }
        public string tenure { get; set; }
        public int No_of_installments { get; set; }
        public long Reference_Number { get; set; }
        public int ID { get; set; }
        public long loanAmount { get; set; }
        public int Elgible_Amount { get; set; }
        public int ROI { get; set; }
       
    }
}
