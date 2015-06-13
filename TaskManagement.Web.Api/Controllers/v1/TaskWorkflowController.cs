using System.Web.Http;
using TaskManagement.Common;
using TaskManagement.Web.Api.MaintenanceProcessing;
using TaskManagement.Web.Api.Models;
using TaskManagement.Web.Common;
using TaskManagement.Web.Common.Routing;
using TaskManagement.Web.Common.Security;

namespace TaskManagement.Web.Api.Controllers.v1
{
    [ApiVersion1RoutePrefix("")]
    [UnitOfWorkActionFilter]
    [Authorize(Roles = Constants.RoleNames.SeniorWorker)]
    public class TaskWorkflowController : ApiController
    {
        private readonly IStartTaskWorkflowProcessor _startTaskWorkflowProcessor;
        private readonly ICompleteTaskWorkflowProcessor _completeTaskWorkflowProcessor;
        private readonly IReactivateTaskWorkflowProcessor _reactivateTaskWorkflowProcessor;

        public TaskWorkflowController(IStartTaskWorkflowProcessor startTaskWorkflowProcessor, ICompleteTaskWorkflowProcessor completeTaskWorkflowProcessor, IReactivateTaskWorkflowProcessor reactivateTaskWorkflowProcessor)
        {
            _startTaskWorkflowProcessor = startTaskWorkflowProcessor;
            _completeTaskWorkflowProcessor = completeTaskWorkflowProcessor;
            _reactivateTaskWorkflowProcessor = reactivateTaskWorkflowProcessor;
        }

        [HttpPost]        
        [Route("tasks/{taskId:long}/activations", Name = "StartTaskRoute")]
        public Task StartTask(long taskId)
        {
            var task = _startTaskWorkflowProcessor.StartTask(taskId);
            return task;
        }

        [HttpPost]
        [Route("tasks/{taskId:long}/completions", Name = "CompleteTaskRoute")]
        public Task CompleteTask(long taskId)
        {
            var task = _completeTaskWorkflowProcessor.CompleteTask(taskId);
            return task;
        }

        [HttpPost]
        [Route("tasks/{taskId:long}/reactivations", Name = "ReactivateTaskRoute")]
        [UserAudit]
        public Task ReactivateTask(long taskId)
        {
            var task = _reactivateTaskWorkflowProcessor.ReactivateTask(taskId);
            return task;
        }

    }
}
