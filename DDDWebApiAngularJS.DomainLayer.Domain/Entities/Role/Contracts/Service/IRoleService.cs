using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Service
{
    public interface IRoleService : IDisposable
    {
        Task<IEnumerable<RoleModel>> GetAllAsync();

        Task CreateAsync(string name, int roleGroup);
    }
}
