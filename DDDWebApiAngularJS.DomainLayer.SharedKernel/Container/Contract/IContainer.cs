using System;
using System.Collections.Generic;

namespace DDDWebApiAngularJS.DomainLayer.SharedKernel.Container.Contract
{
    public interface IContainer
    {
        TEntity GetService<TEntity>();

        object GetService(Type serviceType);

        IEnumerable<TEntity> GetServices<TEntity>();

        IEnumerable<object> GetServices(Type serviceType);
    }
}
