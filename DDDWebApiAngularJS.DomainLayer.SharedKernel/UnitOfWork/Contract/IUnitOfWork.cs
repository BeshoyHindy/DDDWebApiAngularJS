using System;

namespace DDDWebApiAngularJS.DomainLayer.SharedKernel.UnitOfWork.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void Commit();
    }
}
