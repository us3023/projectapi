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
    [Route("api/UserTable")]
    [ApiController]
    public class UserTableController : ControllerBase
    {
        private readonly IUserTableRepo _userRepo;
        public UserTableController(IUserTableRepo userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpPost("authenticate")]
        // [Route("[controller]")]
        public IActionResult Authenticate([FromBody] UserTable model)
        {
            var user = _userRepo.Authenticate(model.Emai_ID, model.Password);
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
            if (user == null)
            {
                return BadRequest("Some error Occured");
            }
            return Ok(user);
        }
    }
}
