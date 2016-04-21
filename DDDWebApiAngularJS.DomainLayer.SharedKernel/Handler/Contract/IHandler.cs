using DDDWebApiAngularJS.DomainLayer.SharedKernel.Event.Contract;
using System;
using System.Collections.Generic;

namespace DDDWebApiAngularJS.DomainLayer.SharedKernel.Handler.Contract
{
    public interface IHandler<TEntity> : IDisposable where TEntity : IDomainEvent
    {
        void Handle(TEntity args);

        IEnumerable<TEntity> Notify();

        bool HasNotifications();
    }
}
