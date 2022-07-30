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

            public bool IsUniqueUser(string username)
        {
            throw new NotImplementedException();
        }

        public UserTable Register(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
