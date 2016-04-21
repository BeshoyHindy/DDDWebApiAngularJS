using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.ApplicationService
{
    public interface IRoleApplicationService : IDisposable
    {
        Task<IEnumerable<RoleModel>> GetAllAsync();

        Task CreateAsync(string name, int roleGroup);

        //Task UpdateAsync(string id, string name);

        //Task DeleteAsync(string id);
    }
}
