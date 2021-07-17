using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPIExample.Common
{
    public static class JWTHelper
    {
        public static dynamic DecodeJWT(string token)
        {
            var EncodedString = token.Substring(7);
            var data = new JwtSecurityToken(jwtEncodedString: EncodedString);
            var userClaimInfo = data.Claims.ToList();
            return userClaimInfo[2].Value;
        }
    }
}
