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
    [Route("api/User")]
    [ApiController]
    public class UserTableController : ControllerBase
    {
        private readonly IUserTableRepo _userRepo;
        public UserTableController(IUserTableRepo userRepo)
        {
            _userRepo = userRepo;
        }
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
        [HttpGet("GetAll")]
        public JsonResult GetAllUsers()
        {
            var users = _userRepo.GetAllUsers();
            return new JsonResult(users);
        }
        //get a single user
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
        //add a single user
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
        //updating a user
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
        //deleting a user
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
