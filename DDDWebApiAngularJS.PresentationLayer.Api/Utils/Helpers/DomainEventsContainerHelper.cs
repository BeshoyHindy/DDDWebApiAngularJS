using DDDWebApiAngularJS.DomainLayer.SharedKernel.Container.Contract;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace DDDWebApiAngularJS.PresentationLayer.Api.Utils.Helpers
{
    public class DomainEventsContainerHelper : IContainer
    {
        private IDependencyResolver resolver;

        public DomainEventsContainerHelper(IDependencyResolver resolver)
        {
            this.resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            return resolver.GetService(serviceType);
        }

        public TEntity GetService<TEntity>()
        {
            return (TEntity)resolver.GetService(typeof(TEntity));
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return resolver.GetServices(serviceType);
        }

        public IEnumerable<TEntity> GetServices<TEntity>()
        {
            return (IEnumerable<TEntity>)resolver.GetServices(typeof(TEntity));
        }
    }
}
