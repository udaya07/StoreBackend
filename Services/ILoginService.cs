using StoreBackEnd.Dto;
using StoreBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StoreBackEnd.Dto.PayloadDto;

namespace StoreBackEnd.Services
{
  public  interface ILoginService
    {
        string PostSignupDetails(SignupDetails signupDetails);

        TokenDto GenerateUserJwt(UserDefn userDefn);

        TokenDto UserCheck(LoginDto userLogin);
    }
}
