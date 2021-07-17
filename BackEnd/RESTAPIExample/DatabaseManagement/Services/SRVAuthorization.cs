using DatabaseManagement.CommonUtills;
using DatabaseManagement.Interfaces;
using DatabaseManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace DatabaseManagement.Services
{
    public class SRVAuthorization : IAuthorization
    {
        private readonly IConfiguration _configuration;
        private readonly RESTAPIExample_DBContext _context;
        public SRVAuthorization(IConfiguration configuration, RESTAPIExample_DBContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        #region Public Methods
        public async Task<Tuple<VMUserLoginResponse, string, bool>> Signin(VMLoginInput model)
        {
            // temp commented for password bypassing
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == model.Email.ToLower() && x.Password == model.Password);
            VMUserLoginResponse vMUsers = new VMUserLoginResponse();
            try
            {
                if (user == null)
                {
                    model.Password = "";
                    return Tuple.Create(vMUsers, "Username or password is incorrect.", false);
                }
                if (user != null)
                {
                    var userDetails = await GetAuthDetails(user.UserId);                    
                    model.Password = "";

                    return Tuple.Create(userDetails, "true", true);
                }
                model.Password = "";
                return Tuple.Create(vMUsers, "Some error has been occured", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Private Methods
        private async Task<VMUserLoginResponse> GetAuthDetails(int userId)
        {
            try
            {
                var returnUser = new VMUserLoginResponse();
                if (userId > 0)
                {
                    var dbUser = await GetUserById(userId);
                    var token = await GenerateJWTToken(dbUser);
                    returnUser.jwt = token;
                    return returnUser;
                }
                else
                {
                    return returnUser;
                }
            }
            catch (Exception)
            {
                return new VMUserLoginResponse();
            }

        }
        private async Task<Tbl_User> GetUserById(int userId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<string> GenerateJWTToken(Tbl_User user)
        {
            // Token Handler is used to create token and convert token to string
            var token_Handler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;

            // Our secret key and which algo we want to use for the encryption
            var credentials = new SigningCredentials(_symmetricKey, SecurityAlgorithms.HmacSha256Signature);

            // Get claims to add in to the token
            var claims = await GetClaims(user);

            // Main settings to generate the token for the client
            var securitytokenDescriptor = new SecurityTokenDescriptor
            {
                // setting the claims which are decoded into the token
                Subject = claims,
                // Expiration of the token 60 mints
                Expires = now.AddDays(_validDays),
                // Secret key and our algo which is used to create signin Cridentials
                SigningCredentials = credentials,
                // Issued date that is used to save in token
                IssuedAt = now
            };
            // Token handler will create that token here through our setting which we created above
            var stoken = token_Handler.CreateToken(securitytokenDescriptor);
            // Convert security token into the string format that will be usefull for client
            var token = token_Handler.WriteToken(stoken);

            return token;
        }
        private SymmetricSecurityKey _symmetricKey
        {
            get
            {
                return AppSettings.Instance.symmetricKey;
            }
        }
        private int _validDays
        {
            get
            {
                return AppSettings.Instance._validDays;
            }
        }
        private async Task<ClaimsIdentity> GetClaims(Tbl_User user)
        {
            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", user.UserId.ToString()),
            });
            return claims;
        }
        #endregion
    }
}
