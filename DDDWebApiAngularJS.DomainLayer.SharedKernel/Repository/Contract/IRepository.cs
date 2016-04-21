using System;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.DomainLayer.SharedKernel.Repository.Contract
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task CreateAsync(TEntity obj);

        Task UpdateAsync(TEntity obj);

        Task DeleteAsync(TEntity obj);
    }
}
