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
        /**
         * @params repo
         * Dependency Injection
         */

        private readonly IUserAccountRepo _repo;

        public UserAccount(IUserAccountRepo repo)
        {
            this._repo = repo;
        }

        /**
        * @params userAccountTable from body
        * @return Ok type ( all the user )
        * POST METHOD for creating account of the user
        */

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


        /**
         * @params  id from route
         * GET METHOD for getting user account 
         * @return ok type ( user account )
         */

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

        /**
         * GET METHOD for getting all the accounts 
         * @return JSON
         */

        [HttpGet("GetAllAcc")]
        public JsonResult GetAllAcc()
        {
            var accs = _repo.GetAllAcc();
            return new JsonResult(accs);
        }

        /**
         * @params account status from route
         * GET METHOD for getting all accounts according to status
         * @retrun JSON
         */

        [HttpGet("GetAllAccByStatus/{status}")]
        public JsonResult GetAllAccByStatus([FromRoute] string status)
        {
            var accs = _repo.GetAllAccByStatus(status);
            return new JsonResult(accs);
        }


        /**
         * @parmams id from route and userAccountTable from body
         * PUT  METHOD for updatation of account
         * @return ok type of existing account or NotFound 
         */

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

        /**
         * @params id from route
         * GET METHOD for getting account  using id
         * @return JSON or BadRequest
         */
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
