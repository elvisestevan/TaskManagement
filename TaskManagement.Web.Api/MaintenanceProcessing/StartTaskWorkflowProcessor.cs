using TaskManagement.Common;
using TaskManagement.Common.TypeMapping;
using TaskManagement.Data.Exceptions;
using TaskManagement.Data.QueryProcessors;
using TaskManagement.Web.Api.Models;

namespace TaskManagement.Web.Api.MaintenanceProcessing
{
    public class StartTaskWorkflowProcessor : IStartTaskWorkflowProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly ITaskByIdQueryProcessor _taskByIdQueryProcessor;
        private readonly IDateTime _dateTime;
        private readonly IUpdateTaskStatusQueryProcessor _updateTaskStatusQueryProcessor;

        public StartTaskWorkflowProcessor(IAutoMapper autoMapper, ITaskByIdQueryProcessor taskByIdQueryProcessor, IDateTime dateTime, IUpdateTaskStatusQueryProcessor updateTaskStatusQueryProcessor)
        {
            _taskByIdQueryProcessor = taskByIdQueryProcessor;
            _autoMapper = autoMapper;
            _dateTime = dateTime;
            _updateTaskStatusQueryProcessor = updateTaskStatusQueryProcessor;
        }

        public Task StartTask(long taskId)
        {
            var taskEntity = _taskByIdQueryProcessor.GetTask(taskId);
            if (taskEntity == null)
            {
                throw new RootObjectNotFoundException("Task Not Found");
            }

            if (taskEntity.Status.Name != "Not Started")
            {
                throw new BusinessRuleViolationException("Incorret task status. Expected status of 'Not Started'");
            }

            taskEntity.StartDate = _dateTime.UtcNow;
            _updateTaskStatusQueryProcessor.UpdateTaskStatus(taskEntity, "In Progress");

            var task = _autoMapper.Map<Task>(taskEntity);

            return task;
        }

    }
}