using TaskManagement.Web.Api.Models;

namespace TaskManagement.Web.Api.MaintenanceProcessing
{
    public interface IReactivateTaskWorkflowProcessor
    {
        Task ReactivateTask(long taskId);
    }
}
