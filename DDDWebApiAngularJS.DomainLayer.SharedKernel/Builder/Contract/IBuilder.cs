using System;

namespace DDDWebApiAngularJS.DomainLayer.SharedKernel.Builder.Contract
{
    public interface IBuilder<TEntity> : IDisposable where TEntity : class
    {
        TEntity Build();
    }
}
