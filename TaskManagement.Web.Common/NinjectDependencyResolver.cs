using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;

namespace TaskManagement.Web.Common
{
    public sealed class NinjectDependencyResolver : IDependencyResolver
    {

        private readonly IKernel _container;

        public NinjectDependencyResolver(IKernel container)
        {
            this._container = container;
        }

        public IKernel Container { get { return this._container; } }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return this._container.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._container.GetAll(serviceType);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
