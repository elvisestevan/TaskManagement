using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagement.Common.TypeMapping;
using AutoMapper;
using TaskManagement.Data.Entities;


namespace TaskManagement.Web.Api.AutoMappingConfiguration
{
    public class StatusEntityToStatusAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Status, Models.Status>();
        }
    }
}