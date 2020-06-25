using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Dto
{
    public class SignupDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string RoleName { get; set; }
    }
}
