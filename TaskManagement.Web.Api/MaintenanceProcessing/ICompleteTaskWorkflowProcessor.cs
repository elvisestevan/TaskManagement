using TaskManagement.Web.Api.Models;

namespace TaskManagement.Web.Api.MaintenanceProcessing
{
    public interface ICompleteTaskWorkflowProcessor
    {
        Task CompleteTask(long taskId);
    }
}
