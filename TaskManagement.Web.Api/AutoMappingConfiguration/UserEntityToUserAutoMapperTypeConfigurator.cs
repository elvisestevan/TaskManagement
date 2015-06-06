using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagement.Common.TypeMapping;
using TaskManagement.Data.Entities;

namespace TaskManagement.Web.Api.AutoMappingConfiguration
{
    public class UserEntityToUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<User, Models.User>()
                .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }
}