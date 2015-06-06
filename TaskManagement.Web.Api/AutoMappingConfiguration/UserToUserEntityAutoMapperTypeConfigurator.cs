using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagement.Common.TypeMapping;
using TaskManagement.Web.Api.Models;

namespace TaskManagement.Web.Api.AutoMappingConfiguration
{
    public class UserToUserEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<User, Data.Entities.User>()
                .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }
}