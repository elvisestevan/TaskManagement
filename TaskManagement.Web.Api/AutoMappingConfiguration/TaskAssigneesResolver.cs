using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TaskManagement.Common.TypeMapping;
using TaskManagement.Data.Entities;
using TaskManagement.Web.Common;
using User = TaskManagement.Web.Api.Models.User;

namespace TaskManagement.Web.Api.AutoMappingConfiguration
{
    public class TaskAssigneesResolver : ValueResolver<Task, List<User>>
    {

        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override List<User> ResolveCore(Task source)
        {
            return source.Users.Select(x => AutoMapper.Map<User>(x)).ToList();
        }
    }
}