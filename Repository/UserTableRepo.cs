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

        public UserTableRepo(DatabaseContext db, IOptions<AppSettings> appsettings)
        {
            _db = db;
            _appSettings = appsettings.Value;
        }

        public UserTable Authenticate(string mail, string pass)
        {
            var user = _db.UserTable.SingleOrDefault(x => x.Emai_ID == mail && x.Password == pass);
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

                    new Claim(ClaimTypes.Name,user.ID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            user.Token = tokenhandler.WriteToken(token);
            return user;
        }

        public UserTable CreateUser(UserTable model)
        {
            try
            {
                var user = _db.UserTable.FirstOrDefault(x => x.Emai_ID == model.Emai_ID);
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
        public List<UserTable> GetAllUsers()
        {
            var users =  _db.UserTable.ToList();
            return users;
        }
        public UserTable GetUser(int id)
        {
            return _db.UserTable.FirstOrDefault(x => x.ID == id);
        } 
        public bool AddUser(UserTable userTable)
        {
            var user = _db.UserTable.FirstOrDefault(x => x.Emai_ID == userTable.Emai_ID);
            if (user != null)
            {
                return false;
            }
            _db.UserTable.Add(userTable);
            _db.SaveChanges();
            return true;
        }

        public UserTable UpdateUser( int id,UserTable userTable)
        {
            var existingUser = _db.UserTable.FirstOrDefault(x => x.ID == id);
            if(existingUser == null)
            {
                return null;
            }
            existingUser.Emai_ID = userTable.Emai_ID;
            existingUser.DOB = userTable.DOB;
            existingUser.Password = userTable.Password;
            _db.SaveChanges();
            return existingUser;
        }
       
        public UserTable DeleteUser( int id)
        {
            var existingUser = _db.UserTable.FirstOrDefault(x => x.ID == id);
            _db.Remove(existingUser);
            _db.SaveChanges();

            return existingUser;
        }




    }
}
