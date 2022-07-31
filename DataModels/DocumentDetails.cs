using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.DataModels
{
    public class DocumentDetails

    {   public int ID { get; set; }

        public string Aadhar_Number { get; set; }
        public string PAN { get; set; }
        public string Voter_ID { get; set; }
        public string  Pay_Slip { get; set; }
        public string LOA { get; set; }
        public string NOC { get; set; }


        public string Reg_Details { get; set; }
        public string Collateral { get; set; }

    }
}
