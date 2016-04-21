using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Model;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Repository
{
    public interface IRoleRepository : IRepository<RoleModel>
    {
        Task<IEnumerable<RoleModel>> GetAllAsync();

        Task<RoleModel> GetByIdAsync(Guid id);

        Task<RoleModel> GetByNameAsync(string name);
    }
}
