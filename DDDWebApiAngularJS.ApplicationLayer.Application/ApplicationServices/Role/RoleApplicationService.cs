using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.ApplicationService;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Service;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Model;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.UnitOfWork.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.ApplicationLayer.Application.ApplicationServices.Role
{
    public class RoleApplicationService : IRoleApplicationService
    {
        private readonly IUnitOfWork unitOfWork;        
        private readonly IRoleService service;

        public RoleApplicationService(IUnitOfWork unitOfWork, IRoleService service)
        {
            this.unitOfWork = unitOfWork;            
            this.service = service;
        }

        public async Task<IEnumerable<RoleModel>> GetAllAsync()
        {
            return await service.GetAllAsync();
        }

        public async Task CreateAsync(string name, int roleGroup)
        {
            unitOfWork.BeginTransaction();
            await service.CreateAsync(name, roleGroup);
            unitOfWork.Commit();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
            service.Dispose();
        }
    }
}
