using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectapi.DataModels;
using projectapi.Repository;

namespace projectapi.Controllers
{
    [Route("api/loan")]
    [ApiController]
    public class UserAccount : ControllerBase
    {
        private readonly IUserAccountRepo _repo;

        public UserAccount(IUserAccountRepo repo)
        {
            this._repo = repo;
        }

        //[HttpPost("Create")]

        [HttpGet("Create")]

        public IActionResult CreateAccount()
        {

            UserAccountTable model = new UserAccountTable { 
                Account_ID="1235605",
                Status="Approved",
                Created_At=DateTime.Now,
                Updated_At=DateTime.Now,
                Signature="",
                UserTable = new UserTable { Emai_ID = "31651"},
                UserLoan = new UserLoan
                {
                    Amount=31356165,
                    LoanDetails = new LoanDetails
                    {
                        Amount_Required = 32165432
                    },
                    UserBank = new UserBankDetails
                    {
                        Bank_Name = "xyz"
                    },
                    IncomeDetails = new IncomeDetails
                    {
                        Current_Salary = 23651320
                    },

                }
            };
            var res = _repo.CreateAccount(model);
            if (res == null)
            {
                return BadRequest("Some error Occured");
            }
            return Ok(res);
        }

        //public IActionResult CreateAccount([FromBody] UserAccountTable model)
        //{
        //    var res = _repo.CreateAccount(model);
        //    if (res == null)
        //    {
        //        return BadRequest("Some error Occured");
        //    }
        //    return Ok(res);
        //}

    }
}
