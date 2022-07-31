//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using projectapi.DataModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;



//namespace projectapi.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class PasswordController : Controller
//    {
//        private readonly DatabaseContext databaseContext;



//        public PasswordController(DatabaseContext databaseContext)
//        {
//            this.databaseContext = databaseContext;
//        }
//        //get all users
//        [HttpGet]
//        public async Task<IActionResult> GetAllUsers()
//        {
//            var users = await databaseContext.UserTable.ToListAsync();
//            return Ok(users);
//        }
//        //get a single user
//        [HttpGet]
//        [Route("{id:int}")]
//        [ActionName("GetUser")]
//        public async Task<IActionResult> GetUser([FromRoute] int id)
//        {
//            var user = await databaseContext.UserTable.FirstOrDefaultAsync(x => x.Id == id);
//            if (user != null)
//            {
//                return Ok(user);
//            }
//            return NotFound("User Not Found");
//        }
//        //add a single user
//        [HttpPost]
//        public async Task<IActionResult> AddUser([FromBody] UserTable userTable)
//        {
//            await databaseContext.UserTable.AddAsync(userTable);
//            await databaseContext.SaveChangesAsync();
//            return CreatedAtAction(nameof(GetUser), new { id = userTable.Id }, userTable);
//        }
//        //updating a user
//        [HttpPut]
//        [Route("{id:int}")]



//        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserTable userTable)
//        {
//            var existingUser = await databaseContext.UserTable.FirstOrDefaultAsync(x => x.Id == id);
//            if (existingUser != null)
//            {
//                existingUser.emailId = userTable.emailId;
//                existingUser.DOB = userTable.DOB;
//                existingUser.Password = userTable.Password;
//                await databaseContext.SaveChangesAsync();
//                return Ok(existingUser);
//            }
//            return NotFound("User Not Found");
//        }
//        //deleting a user
//        [HttpDelete]
//        [Route("{id:int}")]
//        public async Task<IActionResult> DeleteUser([FromRoute] int id)
//        {
//            var existingUser = await databaseContext.UserTable.FirstOrDefaultAsync(x => x.Id == id);
//            if (existingUser != null)
//            {
//                databaseContext.Remove(existingUser);
//                await databaseContext.SaveChangesAsync();
//                return Ok(existingUser);
//            }
//            return NotFound("User Not Found");
//        }

//    }
//}