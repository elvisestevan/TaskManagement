using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net.Config;
using TaskManagement.Common;
using TaskManagement.Common.Logging;
using TaskManagement.Web.Common;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using Ninject.Activation;
using Ninject.Web.Common;
using TaskManagement.Data.SqlServer.Mapping;
using TaskManagement.Web.Common.Security;
using TaskManagement.Common.Security;
using TaskManagement.Data.SqlServer.QueryProcessors;
using TaskManagement.Data.QueryProcessors;
using TaskManagement.Common.TypeMapping;
using TaskManagement.Web.Api.AutoMappingConfiguration;
using TaskManagement.Web.Api.MaintenanceProcessing;
using TaskManagement.Web.Api.Security;
using TaskManagement.Web.Api.InquiryProcessing;

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
            ConfigureUserSession(container);
            ConfigureNHibernate(container);
            ConfigureAutoMapper(container);

            container.Bind<IDateTime>().To<DateTimeAdapter>().InSingletonScope();
            container.Bind<IAddTaskQueryProcessor>().To<AddTaskQueryProcessor>().InRequestScope();
            container.Bind<IAddTaskMaintenanceProcessor>().To<AddTaskMaintenanceProcessor>().InRequestScope();
            container.Bind<IBasicSecurityService>().To<BasicSecurityService>().InSingletonScope();
            container.Bind<ITaskByIdQueryProcessor>().To<TaskByIdQueryProcessor>().InRequestScope();
            container.Bind<IUpdateTaskStatusQueryProcessor>().To<UpdateTaskStatusQueryProcessor>().InRequestScope();
            container.Bind<IStartTaskWorkflowProcessor>().To<StartTaskWorkflowProcessor>().InRequestScope();
            container.Bind<ICompleteTaskWorkflowProcessor>().To<CompleteTaskWorkflowProcessor>().InRequestScope();
            container.Bind<IReactivateTaskWorkflowProcessor>().To<ReactivateTaskWorkflowProcessor>().InRequestScope();
            container.Bind<ITaskByIdInquiryProcessor>().To<TaskByIdInquiryProcessor>().InRequestScope();
        }

        private void ConfigureLog4Net(IKernel container)
        {
            XmlConfigurator.Configure();

            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }

        private void ConfigureNHibernate(IKernel container)
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                c => c.FromConnectionStringWithKey("TaskManagementDb")))
                .CurrentSessionContext("web")
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TaskMap>())
                .BuildSessionFactory();

            container.Bind<ISessionFactory>().ToConstant(sessionFactory);
            container.Bind<ISession>().ToMethod(CreateSession).InRequestScope();
            container.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>().InRequestScope();
        }

        private ISession CreateSession(IContext context)
        {
            var sessionFactory = context.Kernel.Get<ISessionFactory>();
            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }

            return sessionFactory.GetCurrentSession();
        }

        private void ConfigureUserSession(IKernel container)
        {
            var userSession = new UserSession();
            container.Bind<IUserSession>().ToConstant(userSession).InSingletonScope();
            container.Bind<IWebUserSession>().ToConstant(userSession).InSingletonScope();
        }

        private void ConfigureAutoMapper(IKernel container)
        {
            container.Bind<IAutoMapper>().To<AutoMapperAdapter>().InSingletonScope();

            container.Bind<IAutoMapperTypeConfigurator>()
            .To<StatusEntityToStatusAutoMapperTypeConfigurator>()
            .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
            .To<StatusToStatusEntityAutoMapperTypeConfigurator>()
            .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
            .To<UserEntityToUserAutoMapperTypeConfigurator>()
            .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
            .To<UserToUserEntityAutoMapperTypeConfigurator>()
            .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
            .To<NewTaskToTaskEntityAutoMapperTypeConfigurator>()
            .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
            .To<TaskEntityToTaskAutoMapperTypeConfigurator>()
            .InSingletonScope();
        }
    }
}