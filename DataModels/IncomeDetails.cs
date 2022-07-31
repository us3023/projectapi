using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.DataModels
{
    public class IncomeDetails
    {
        public int ID { get; set; }
        public long Current_Salary { get; set; }
        public string Prop_Location { get; set; }
        public string Name { get; set; }
        public long Estimated_Cost { get; set; }
        public string Occupation { get; set; }
        public string Employer_Name { get; set; }
         public string Emp_Type { get; set; }
        public int Retirement_Age { get; set; }
        public string Property_Name { get; set; }


    }
}
