using NHibernate;
using NHibernate.Util;
using TaskManagement.Common;
using TaskManagement.Common.Security;
using TaskManagement.Data.Entities;
using TaskManagement.Data.Exceptions;
using TaskManagement.Data.QueryProcessors;
using TaskManagement.Web.Common;

namespace TaskManagement.Data.SqlServer.QueryProcessors
{
    public class AddTaskQueryProcessor : IAddTaskQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddTaskQueryProcessor(ISession session, IUserSession userSession, IDateTime dateTime)
        {
            _session = session;
            _userSession = userSession;
            _dateTime = dateTime;
        }

        public void AddTask(Task task)
        {
            task.CreatedDate = _dateTime.UtcNow;
            task.Status = _session.QueryOver<Status>().Where(x => x.Name == "Not Started").SingleOrDefault();
            //task.CreatedBy = _session.QueryOver<User>().Where(x => x.Username == _userSession.Username).SingleOrDefault();
            task.CreatedBy = _session.Get<User>(1L);

            if (task.Users != null && task.Users.Any())
            {
                for (var i = 0; i < task.Users.Count; i++)
                {
                    var user = task.Users[i];
                    var persistedUser = _session.Get<User>(user.UserId);
                    if (persistedUser == null)
                    {
                        throw new ChildObjectNotFoundException(string.Format("User [{0}] Not Found", user.UserId));
                    }
                    task.Users[i] = persistedUser;
                }
            }

            _session.SaveOrUpdate(task);
        }
    }
}
