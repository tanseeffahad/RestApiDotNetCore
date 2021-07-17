using AutoMapper.Configuration;
using DatabaseManagement.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTAPIExample.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace RESTAPIExample.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class AthenticationController : Controller
    {
        private readonly IAuthorization _authorization;

        public AthenticationController(IAuthorization authorization)
        {
            _authorization = authorization;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] VMLoginInput model)
        {
            try
            {
                if (!String.IsNullOrEmpty(model.Email) && !String.IsNullOrEmpty(model.Password))
                {
                    VMUserLoginResponse vMUsers = new VMUserLoginResponse();

                    Tuple<VMUserLoginResponse, string, bool> tuple = await _authorization.Signin(model);
                    var response = new ApiResponse<VMUserLoginResponse>
                    {
                        Message = tuple.Item2 == "false" ? "Invalid Email or Password" : tuple.Item2,
                        Success = tuple.Item3,
                        Response = tuple.Item2 == "false" ? null : tuple.Item1
                    };
                    return Ok(response);
                }
                else
                    return BadRequest("Invalid Username or Password");
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>
                {
                    Message = "Error",
                    Success = false,
                    Response = ex.InnerException != null ? ex.InnerException.Message : ex.Message
                });
            }

        }
    }

}
