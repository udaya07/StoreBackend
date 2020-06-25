using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StoreBackEnd.Dto;
using StoreBackEnd.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static StoreBackEnd.Dto.PayloadDto;

namespace StoreBackEnd.Services
{
    public class LoginService :ILoginService
    {
       private AppDbContext appDbContext;
        private IConfiguration configuration;
        public LoginService(AppDbContext appDbContext, IConfiguration configuration)
        {

            this.appDbContext = appDbContext;
            this.configuration = configuration;

        }
        public string PostSignupDetails(SignupDetails signupDetails)
        {
            try
            {
                var result = (from r in appDbContext.UserDefn where (r.UserName == signupDetails.UserName && r.MobileNumber == signupDetails.MobileNumber) select r).ToList();
                if (result.Count == 0)
                {
                    var user = new UserDefn
                    {
                        UserName = signupDetails.UserName,
                        MobileNumber = signupDetails.MobileNumber,
                        Password = signupDetails.Password,
                        EmailId = signupDetails.EmailId,
                        RoleName = "User"
                    };
                    appDbContext.UserDefn.Add(user);
                    appDbContext.SaveChanges();
                    return "Posted";
                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }



       
        public TokenDto UserCheck(LoginDto userLogin)
        {
            var user = appDbContext.UserDefn.Where(x => x.UserName == userLogin.UserName && x.Password == userLogin.Password).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            else
            {

                return GenerateUserJwt(user);
            }
        }
        public TokenDto GenerateUserJwt(UserDefn userDefn)
        {
            var key = configuration.GetValue<string>("SecretKey");
            var symmetricToken = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var SigningCredentials = new SigningCredentials(symmetricToken, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>();
            claims.Add(new Claim("UserName", userDefn.UserName));
            claims.Add(new Claim("UserId", userDefn.Id.ToString()));

            claims.Add(new Claim("EmailId", userDefn.EmailId.ToString()));
            claims.Add(new Claim("MobileNumber", userDefn.MobileNumber));


            var tokenDescriptor = new JwtSecurityToken(
                   issuer: "StoreAdmin",
                   audience: "StoreUser",

                   signingCredentials: SigningCredentials,
                   expires: DateTime.Now.AddHours(2),
                   claims: claims
               );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);


            TokenDto returnToken = new TokenDto();
            returnToken.token = token;
            return returnToken;
        }


///////////////////////////////////////////



















    }
}
