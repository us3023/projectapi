using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.DataModels
{
    public class UserTable
    {
        public string firstName { get; set; } 
        public int Id { get; set; }
        public bool Is_Admin { get; set; }
        public string middleName { get; set; } 
        public string lastName { get; set; }     
        public string emailId { get; set; } 
        public string Password { get; set; } 
        public long phNumber { get; set; } 
        public DateTime DOB { get; set; } 
        //public long  { get; set; }
       // public DateTime DOB { get; set; }
        public string gender { get; set; } 
        public string nationality { get; set; } 

        public string adharNo { get; set; } 
        public string panId { get; set; }  
        [NotMapped]
        public string Token { get; set; } 


    }
}
