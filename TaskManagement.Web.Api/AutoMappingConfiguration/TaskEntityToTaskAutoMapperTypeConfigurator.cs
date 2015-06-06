using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagement.Common.TypeMapping;
using TaskManagement.Data.Entities;

namespace TaskManagement.Web.Api.AutoMappingConfiguration
{
    public class TaskEntityToTaskAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Task, Models.Task>()
                .ForMember(opt => opt.Links, x => x.Ignore())
                .ForMember(opt => opt.Assignees, x => x.ResolveUsing<TaskAssigneesResolver>());

        }

    }
}