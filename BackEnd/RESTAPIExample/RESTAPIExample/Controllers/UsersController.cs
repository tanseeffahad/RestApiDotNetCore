using DatabaseManagement.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RESTAPIExample.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace BOS_Internal.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISRVUser _users;

        public UsersController(ISRVUser users)
        {
            _users = users;

        }        
        // POST: Users/Save
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public IActionResult Save(VMUser model)
        {
            try
            {
                //model.CurUserID = Convert.ToInt32(JWTHelper.DecodeJWT(Request.Headers["Authorization"]));
                Tuple<List<VMUserResponse>, string, bool> tuple = _users.SaveUsers(model);
                var response = new ApiResponse<List<VMUserResponse>>
                {
                    Response = tuple.Item1,
                    Message = tuple.Item2,
                    Success = tuple.Item3,

                };
                return Ok(response);
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
        // GET: Users/listOfUser
        [HttpGet]
        [Route("user")]
        public IActionResult listOfUser()
        {
            try
            {
                Tuple<List<VMUserResponse>, string, bool> tuple = _users.listOfUser();
                var response = new ApiResponse<List<VMUserResponse>>
                {
                    Response = tuple.Item1,
                    Message = tuple.Item2,
                    Success = tuple.Item3,

                };
                return Ok(response);
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
