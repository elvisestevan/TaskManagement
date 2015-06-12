using NHibernate;
using TaskManagement.Data.Entities;
using TaskManagement.Data.QueryProcessors;

namespace TaskManagement.Data.SqlServer.QueryProcessors
{
    public class TaskByIdQueryProcessor : ITaskByIdQueryProcessor
    {
        private readonly ISession _session;

        public TaskByIdQueryProcessor(ISession session)
        {
            _session = session;
        }

        public Task GetTask(long taskId)
        {
            var task = _session.Get<Task>(taskId);
            return task;
        }
    }
}
