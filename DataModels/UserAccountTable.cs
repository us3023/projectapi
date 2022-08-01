using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.DataModels
{
    public class UserAccountTable
    {
        public int ID { get; set; }
        public string Account_ID { get; set; }
        public string Status { get; set; }

        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string Signature { get; set; }
        //navigation user table , user loan details , 
        public UserTable UserTable { get; set; }
        public UserLoan UserLoan { get; set; }
        

    }
}
