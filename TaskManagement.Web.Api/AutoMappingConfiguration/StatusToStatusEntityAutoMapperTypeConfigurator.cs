using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagement.Common.TypeMapping;
using AutoMapper;
using TaskManagement.Web.Api.Models;

namespace TaskManagement.Web.Api.AutoMappingConfiguration
{
    public class StatusToStatusEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Status, Data.Entities.Status>()
                .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }
}