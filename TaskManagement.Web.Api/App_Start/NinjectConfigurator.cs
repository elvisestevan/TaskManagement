﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net.Config;
using TaskManagement.Common;
using TaskManagement.Common.Logging;
using TaskManagement.Web.Common;

namespace TaskManagement.Web.Api
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }
        private void AddBindings(IKernel container)
        {
            ConfigureLog4Net(container);

            container.Bind<IDateTime>().To<DateTimeAdapter>().InSingletonScope();
        }

        private void ConfigureLog4Net(IKernel container)
        {
            XmlConfigurator.Configure();

            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }
    }
}