using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectapi.DataModels;
using projectapi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.Controllers
{    
    // API CONTROLLER FOR USER TABLE

    [Route("api/User")]
    [ApiController]
    public class UserTableController : ControllerBase
    {

       /**
        * @params userRepo Interface
        * Dependency Injection for using IUserTable Repository
        */

        private readonly IUserTableRepo _userRepo;
       

        public UserTableController(IUserTableRepo userRepo)
        {
            _userRepo = userRepo;
        }

        /**
         * @params userTable model from  body
         * POST METHOD for Authentication 
         * @return OK type of user or Bad Request
         */
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserTable model)
        {
            var user = _userRepo.Authenticate(model.emailId, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Email or Password is incorrect" });

            }
            return Ok(user);
        }

        /**
         * @params userTable model 
         * POST METHOD for creating a new User
         * @return ok type of user 
         */

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserTable model)
        {
            var user = _userRepo.CreateUser(model);
            if(user == null)
            {
                return BadRequest("Some error Occured");
            }
            return Ok(user);
        }

        /**
         * GET METHOD for getting all Users
         * @ return JSON 
         */

        [HttpGet("GetAll")]
        public JsonResult GetAllUsers()
        {
            var users = _userRepo.GetAllUsers();
            return new JsonResult(users);
        }

       
        // GET METHOD for getting a single user using id 

        [HttpGet("GetUser/{id:int}")]
        public IActionResult GetUser([FromRoute] int id)
        {
            var user = _userRepo.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest("User Not Found");
        }

        // POST METHOD for adding a single user
        
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] UserTable userTable)
        {
            var user = _userRepo.AddUser(userTable);
            if(user == false)
            {
                return BadRequest("Existing User found in the system.");
            }
            return Ok(user);

        }

        // PUT METHOD for updating a single user 
        
        [HttpPut("UpdateUser/{id:int}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserTable userTable)
        {
            var existingUser = _userRepo.UpdateUser(id,userTable);
            if (existingUser != null)
            {
                return Ok(existingUser);
            }
            return NotFound("User Not Found");
        }

        // DELETE METHOD for deleting a user

        [HttpDelete("Delete/{id:int}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var existingUser = _userRepo.DeleteUser(id);
            if (existingUser == null)
            {
                return NotFound("User Not Found");
            }
            return Ok(existingUser);
        }
    }
}
