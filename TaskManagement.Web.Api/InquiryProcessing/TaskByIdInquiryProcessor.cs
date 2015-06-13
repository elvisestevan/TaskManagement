using TaskManagement.Common.TypeMapping;
using TaskManagement.Data.QueryProcessors;
using TaskManagement.Data.Exceptions;
using TaskManagement.Web.Api.Models;

namespace TaskManagement.Web.Api.InquiryProcessing
{
    public class TaskByIdInquiryProcessor : ITaskByIdInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly ITaskByIdQueryProcessor _queryProcessor;

        public TaskByIdInquiryProcessor(ITaskByIdQueryProcessor queryProcessor, IAutoMapper autoMapper) {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
        }

        public Task GetTask(long taskId)
        {
            var taskEntity = _queryProcessor.GetTask(taskId);

            if (taskEntity == null)
            {
                throw new RootObjectNotFoundException("Task not found.");
            }

            var task = _autoMapper.Map<Task>(taskEntity);

            return task;
        }

    }
}