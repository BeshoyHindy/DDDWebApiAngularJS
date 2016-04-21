using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Repository;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Model;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.UnitOfWork.Contract;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DDDWebApiAngularJS.InfrastructureLayer.Data.Repositories
{
    public class RoleRepository : Repository<RoleModel>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public Task<IEnumerable<RoleModel>> GetAllAsync()
        {
            return Task.FromResult(
                session.Query<RoleModel>()
                    .AsEnumerable()
            );
        }

        public Task<RoleModel> GetByIdAsync(Guid id)
        {
            return Task.FromResult(
                session.Get<RoleModel>(id)
            );
        }

        public Task<RoleModel> GetByNameAsync(string name)
        {
            return Task.FromResult(
                session.Query<RoleModel>()
                    .Where(x => x.Name.Equals(name))
                    .FirstOrDefault()
            );
        }
    }
}
