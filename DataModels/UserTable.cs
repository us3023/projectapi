using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.DataModels
{
    public class UserTable
    {
        public string First_Name { get; set; }
        //public bool Is_Admin { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string Emai_ID { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }
        public long Phone_Number { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        [NotMapped]
        public string Token { get; set; }



    }
}
