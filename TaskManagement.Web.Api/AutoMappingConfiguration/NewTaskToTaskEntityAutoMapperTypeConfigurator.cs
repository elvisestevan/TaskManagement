using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagement.Common.TypeMapping;
using TaskManagement.Web.Api.Models;

namespace TaskManagement.Web.Api.AutoMappingConfiguration
{
    public class NewTaskToTaskEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NewTask, Data.Entities.Task>()
                .ForMember(opt => opt.Version, x => x.Ignore())
                .ForMember(opt => opt.CreatedBy, x => x.Ignore())
                .ForMember(opt => opt.TaskId, x => x.Ignore())
                .ForMember(opt => opt.CreatedDate, x => x.Ignore())
                .ForMember(opt => opt.CompletedDate, x => x.Ignore())
                .ForMember(opt => opt.Status, x => x.Ignore())
                .ForMember(opt => opt.Users, x => x.Ignore());
        }
    }
}