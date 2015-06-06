using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagement.Common.TypeMapping;

namespace TaskManagement.Web.Api
{
    public class AutoMapperConfigurator
    {
        public void Configure(IEnumerable<IAutoMapperTypeConfigurator> autoMapperTypeConfigurator) 
        {
            autoMapperTypeConfigurator.ToList().ForEach(x => x.Configure());

            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}