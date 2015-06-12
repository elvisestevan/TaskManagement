using TaskManagement.Common;
using TaskManagement.Common.TypeMapping;
using TaskManagement.Data.Exceptions;
using TaskManagement.Data.QueryProcessors;
using TaskManagement.Web.Api.Models;

namespace TaskManagement.Web.Api.MaintenanceProcessing
{
    public class ReactivateTaskWorkflowProcessor : IReactivateTaskWorkflowProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly ITaskByIdQueryProcessor _taskByIdQueryProcessor;
        private readonly IUpdateTaskStatusQueryProcessor _updateTaskStatusQueryProcessor;

        public ReactivateTaskWorkflowProcessor(IAutoMapper autoMapper, ITaskByIdQueryProcessor taskByIdQueryProcessor, IUpdateTaskStatusQueryProcessor updateTaskStatusQueryProcessor)
        {
            _autoMapper = autoMapper;
            _taskByIdQueryProcessor = taskByIdQueryProcessor;
            _updateTaskStatusQueryProcessor = updateTaskStatusQueryProcessor;
        }

        public Task ReactivateTask(long taskId)
        {
            var taskEntity = _taskByIdQueryProcessor.GetTask(taskId);

            if (taskEntity == null)
            {
                throw new RootObjectNotFoundException("Task Not Found");
            }

            if (taskEntity.Status.Name != "Completed")
            {
                throw new BusinessRuleViolationException("Incorrect task status. Expected status of 'Completed'.");
            }

            taskEntity.CompletedDate = null;
            _updateTaskStatusQueryProcessor.UpdateTaskStatus(taskEntity, "In Progress");

            var task = _autoMapper.Map<Task>(taskEntity);

            return task;
        }
    }
}