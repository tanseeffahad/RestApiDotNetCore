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
    public class TaskController : ControllerBase
    {

        private readonly ISRVTasks _tasks;

        public TaskController(ISRVTasks tasks)
        {
            _tasks = tasks;

        }
        // POST: Task/Save
        [HttpPost]
        [Route("create-task")]
        public IActionResult Save(VMTask model)
        {
            try
            {
                //model.CurUserID = Convert.ToInt32(JWTHelper.DecodeJWT(Request.Headers["Authorization"]));
                Tuple<List<VMTask>, string, bool> tuple = _tasks.SaveTasks(model);
                var response = new ApiResponse<List<VMTask>>
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
        // GET: Tasks/Task
        [HttpGet]
        [Route("list-tasks")]
        public IActionResult listOfTask()
        {
            try
            {
                Tuple<List<VMTask>, string, bool> tuple = _tasks.listOfTasks();
                var response = new ApiResponse<List<VMTask>>
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


        [HttpPost]
        [Route("delete-task-bulk")]
        public IActionResult Delete(List<VMTask> model)
        {
            try
            {
                //model.CurUserID = Convert.ToInt32(JWTHelper.DecodeJWT(Request.Headers["Authorization"]));
                Tuple<List<VMTask>, string, bool> tuple = _tasks.UpdateTasks(model);
                var response = new ApiResponse<List<VMTask>>
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
