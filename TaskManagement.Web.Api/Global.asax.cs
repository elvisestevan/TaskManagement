using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using TaskManagement.Common.Logging;
using TaskManagement.Common.TypeMapping;
using TaskManagement.Web.Common;

namespace TaskManagement.Web.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            new AutoMapperConfigurator().Configure(WebContainerManager.GetAll<IAutoMapperTypeConfigurator>());
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            if (exception != null)
            {
                var log = WebContainerManager.Get<ILogManager>().GetLog(typeof(WebApiApplication));
                log.Error("Unhandled exception.", exception);
            }
        }
    }
}
