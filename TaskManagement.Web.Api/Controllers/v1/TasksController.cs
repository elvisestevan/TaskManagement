using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement.Web.Api.Models;
using TaskManagement.Web.Common;
using TaskManagement.Web.Common.Routing;

namespace TaskManagement.Web.Api.Controllers.v1
{
    [ApiVersion1RoutePrefix("tasks")]
    public class TasksController : ApiController
    {

        [Route("", Name = "AddTaskRouteV1")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage request, Task newTask)
        {
            return new Task {
                Subject = "In v1, newTask.Subject = " + newTask.Subject
            };
        }

    }
}
