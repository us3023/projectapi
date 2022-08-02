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

        [HttpPost("CreateACCP")]
        public IActionResult CreateACCP ([FromBody] UserAccountTable userAccountTable)
        {
            var user = _repo.CreateAccount(userAccountTable);
            if (user == null)
            {
                return BadRequest("Some error Occured");
            }
            return Ok(user);

        }

        
        //[HttpGet("Create")]

        //public IActionResult CreateAccount()
        //{

        //    UserAccountTable model = new UserAccountTable { 
        //        Account_ID="1235605",
        //        Status="Approved",
        //        Created_At=DateTime.Now,
        //        Updated_At=DateTime.Now,
        //        Signature="",
        //        UserTable = new UserTable { emailId = "31651"},
        //        UserLoan = new UserLoan
        //        {
        //            Amount = 31356165,
        //            LoanDetails = new LoanDetails
        //            {
        //                Amount_Required = 32165432
        //            },
        //            UserBank = new UserBankDetails
        //            {
        //                Bank_Name = "xyz"
        //            },
        //            IncomeDetails = new IncomeDetails
        //            {
        //                employerName="jhbibasd"
        //            },

        //        }
        //    };
        //    var res = _repo.CreateAccount(model);
        //    if (res == null)
        //    {
        //        return BadRequest("Some error Occured");
        //    }
        //    return Ok(res);
        //}

        //public IActionResult CreateAccount([FromBody] UserAccountTable model)
        //{
        //    var res = _repo.CreateAccount(model);
        //    if (res == null)
        //    {
        //        return BadRequest("Some error Occured");
        //    }
        //    return Ok(res);
        //}
        [HttpGet("Getaccount/{id:int}")]
        public IActionResult Getaccount([FromRoute] int id)
        {
            var acc = _repo.Getaccount(id);
            if (acc != null)
            {
                return Ok(acc);
            }
            return BadRequest("Account Not Found");
        }
        [HttpGet("GetAllAcc")]
        public JsonResult GetAllAcc()
        {
            var accs = _repo.GetAllAcc();
            return new JsonResult(accs);
        }


        [HttpGet("GetAllAccByStatus/{status}")]
        public JsonResult GetAllAccByStatus([FromRoute] string status)
        {
            var accs = _repo.GetAllAccByStatus(status);
            return new JsonResult(accs);
        }




        [HttpPut("UpdateAccount/{id:int}")]
        public IActionResult UpdateAcount([FromRoute] int id, [FromBody] UserAccountTable userAccountTable)
        {
            var existingAcc = _repo.UpdateAccount(id, userAccountTable);
            if (existingAcc!= null)
            {
                return Ok(existingAcc);
            }
            return NotFound("Account Not Found");
        }


        [HttpGet("GetByAccoutNumber/{id}")]
        public IActionResult GetAccountByID([FromRoute] string id)
        {
            var accs = _repo.GetUserLoanByAccount(id);
            if (accs == null)
            {
                return BadRequest("Loan ID Not Found");
            }
            return new JsonResult(accs);
        }


    }
}
