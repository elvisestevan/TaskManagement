using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement.Common;
using TaskManagement.Web.Api.InquiryProcessing;
using TaskManagement.Web.Api.MaintenanceProcessing;
using TaskManagement.Web.Api.Models;
using TaskManagement.Web.Common;
using TaskManagement.Web.Common.Routing;

namespace TaskManagement.Web.Api.Controllers.v1
{
    [ApiVersion1RoutePrefix("tasks")]
    [UnitOfWorkActionFilter]
    [Authorize(Roles = Constants.RoleNames.JuniorWorker)]
    public class TasksController : ApiController
    {

        private readonly IAddTaskMaintenanceProcessor _addTaskMaintenanceProcessor;
        private readonly ITaskByIdInquiryProcessor _taskByIdInquiryProcessor;

        public TasksController(IAddTaskMaintenanceProcessor addTaskMaintenanceProcessor, ITaskByIdInquiryProcessor taskByIdInquiryProcessor)
        {
            _addTaskMaintenanceProcessor = addTaskMaintenanceProcessor;
            _taskByIdInquiryProcessor = taskByIdInquiryProcessor;
        }

        [Route("", Name = "AddTaskRouteV1")]
        [HttpPost]
        [Authorize(Roles = Constants.RoleNames.Manager)]
        public IHttpActionResult AddTask(HttpRequestMessage request, NewTask newTask)
        {
            var task = _addTaskMaintenanceProcessor.AddTask(newTask);
            var result = new TaskCreatedActionResult(request, task);
            return result;
        }

        [Route("{id:long}", Name = "GetTaskRoute")]
        public Task GetTask(long id)
        {
            var task = _taskByIdInquiryProcessor.GetTask(id);
            return task;
        }

    }
}
