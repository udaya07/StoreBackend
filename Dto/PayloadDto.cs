using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Dto
{
    public class PayloadDto
    {
        public class Payload
        {
            //
            // Summary:
            //     The user's email address. This may not be unique and is not suitable for use
            //     as a primary key. Provided only if your scope included the string "email".
            [JsonProperty("email")]
            public string Email { get; set; }
            //
            // Summary:
            //     True if the user's e-mail address has been verified; otherwise false.
            [JsonProperty("email_verified")]
            public bool EmailVerified { get; set; }
            //
            // Summary:
            //     The user's full name, in a displayable form. Might be provided when: (1) The
            //     request scope included the string "profile"; or (2) The ID token is returned
            //     from a token refresh. When name claims are present, you can use them to update
            //     your app's user records. Note that this claim is never guaranteed to be present.
            [JsonProperty("name")]
            public string Name { get; set; }

            //
            // Summary:
            //     The URL of the user's profile picture. Might be provided when: (1) The request
            //     scope included the string "profile"; or (2) The ID token is returned from a token
            //     refresh. When picture claims are present, you can use them to update your app's
            //     user records. Note that this claim is never guaranteed to be present.
            [JsonProperty("picture")]
            public string Picture { get; set; }

        }

        public class TokenDto
        {
            public string token { get; set; }
        }
    }
}
