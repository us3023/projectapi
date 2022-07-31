using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.DataModels
{
    public class UserBankDetails
    {
        public int ID { get; set; }
        public string Bank_Name { get; set; }
        public string Account_Number { get; set; }
        public string Address { get; set; }
        public string IFSC { get; set; }

    }
}
