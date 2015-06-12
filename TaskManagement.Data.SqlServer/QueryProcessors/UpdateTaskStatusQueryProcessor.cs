using NHibernate;
using TaskManagement.Data.Entities;
using TaskManagement.Data.QueryProcessors;

namespace TaskManagement.Data.SqlServer.QueryProcessors
{
    public class UpdateTaskStatusQueryProcessor : IUpdateTaskStatusQueryProcessor
    {
        private readonly ISession _session;

        public UpdateTaskStatusQueryProcessor(ISession session)
        {
            _session = session;
        }

        public void UpdateTaskStatus(Task taskToUpdate, string statusName)
        {
            var status = _session.QueryOver<Status>().Where(x => x.Name == statusName).SingleOrDefault();

            taskToUpdate.Status = status;

            _session.SaveOrUpdate(taskToUpdate);
        }
    }
}
