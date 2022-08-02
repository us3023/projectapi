using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using projectapi.DataModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace projectapi.Repository
{
    public class UserTableRepo : IUserTableRepo
    {
        private readonly DatabaseContext _db;
        private readonly AppSettings _appSettings;
        
        /**
         *  Dependency Injection for usinig DbContext and appsettings 
         */
        public UserTableRepo(DatabaseContext db, IOptions<AppSettings> appsettings)
        {
            _db = db;
            _appSettings = appsettings.Value;
        }

        /** @params mail id and passwords
         *  Using JWT for Authentication 
         *  @ return user after adding token   
         */

        public UserTable Authenticate(string mail, string pass)
        {
            var user = _db.UserTable.SingleOrDefault(x => x.emailId == mail && x.Password == pass);
            if (user == null)
            {
                return null;
            }
            //jwt 
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {

                    new Claim(ClaimTypes.Name , user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            user.Token = tokenhandler.WriteToken(token);
            return user;
        }

        /**
         * @params model of type UserTable
         * Creating a User
         * @return model of userTable
         */
        public UserTable CreateUser(UserTable model)
        {
            try
            {
                var user = _db.UserTable.FirstOrDefault(x => x.emailId == model.emailId);
                if (user == null)
                {
                    return null;
                }
                _db.UserTable.Add(model);
                _db.SaveChanges();
                return user;
                //return user;
            }catch(Exception e)
            {
                return null;
            }
        }

        // List for getting all the users
        public List<UserTable> GetAllUsers()
        {
            var users =  _db.UserTable.ToList();
            return users;
        }
        //getting user using id
        public UserTable GetUser(int id)
        {
            return _db.UserTable.FirstOrDefault(x => x.Id == id);
        } 
        // adding user in the user table
        public bool AddUser(UserTable userTable)
        {
            var user = _db.UserTable.FirstOrDefault(x => x.emailId == userTable.emailId);
            if (user != null)
            {
                return false;
            }
            _db.UserTable.Add(userTable);
            _db.SaveChanges();
            return true;
        }
        // updating user using id 
        public UserTable UpdateUser( int id,UserTable userTable)
        {
            var existingUser = _db.UserTable.FirstOrDefault(x => x.Id == id);
            if(existingUser == null)
            {
                return null;
            }
            existingUser.emailId = userTable.emailId;
            existingUser.DOB = userTable.DOB;
            existingUser.Password = userTable.Password;
            _db.SaveChanges();
            return existingUser;
        }
       // deleting a user 
        public UserTable DeleteUser( int id)
        {
            var existingUser = _db.UserTable.FirstOrDefault(x => x.Id == id);
            _db.Remove(existingUser);
            _db.SaveChanges();
            return existingUser;
        }       
    }
}
