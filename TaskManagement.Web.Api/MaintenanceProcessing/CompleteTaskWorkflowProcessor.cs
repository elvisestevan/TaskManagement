using TaskManagement.Common;
using TaskManagement.Common.TypeMapping;
using TaskManagement.Data.Exceptions;
using TaskManagement.Data.QueryProcessors;
using TaskManagement.Web.Api.Models;

namespace TaskManagement.Web.Api.MaintenanceProcessing
{
    public class CompleteTaskWorkflowProcessor : ICompleteTaskWorkflowProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly ITaskByIdQueryProcessor _taskByIdQueryProcessor;
        private readonly IDateTime _dateTime;
        private readonly IUpdateTaskStatusQueryProcessor _updateTaskStatusQueryProcessor;

        public CompleteTaskWorkflowProcessor(IAutoMapper autoMapper, ITaskByIdQueryProcessor taskByIdQueryProcessor, IDateTime dateTime, IUpdateTaskStatusQueryProcessor updateTaskStatusQueryProcessor)
        {
            _taskByIdQueryProcessor = taskByIdQueryProcessor;
            _autoMapper = autoMapper;
            _dateTime = dateTime;
            _updateTaskStatusQueryProcessor = updateTaskStatusQueryProcessor;
        }

        public Task CompleteTask(long taskId)
        {
            var taskEntity = _taskByIdQueryProcessor.GetTask(taskId);

            if (taskEntity == null)
            {
                throw new RootObjectNotFoundException("Task Not Found");
            }

            if (taskEntity.Status.Name != "In Progress")
            {
                throw new BusinessRuleViolationException("Incorrect task status. Expected status of 'In Progress'.");
            }

            taskEntity.CompletedDate = _dateTime.UtcNow;
            _updateTaskStatusQueryProcessor.UpdateTaskStatus(taskEntity, "Completed");

            var task = _autoMapper.Map<Task>(taskEntity);

            return task;
        }
    }
}