using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Builder;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Repository;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Service;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Model;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Event;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleBuilder builder;
        private readonly IRoleRepository repository;

        public RoleService(IRoleBuilder builder, IRoleRepository repository)
        {
            this.builder = builder;
            this.repository = repository;
        }

        public async Task<IEnumerable<RoleModel>> GetAllAsync()
        {
            IList<RoleModel> roles = new List<RoleModel>();

            foreach (var role in await repository.GetAllAsync())
                roles.Add(new RoleModel(role.Name, role.RoleGroup));

            return roles;
        }

        public async Task CreateAsync(string name, int roleGroup)
        {
            var hasRole = await repository.GetByNameAsync(name);

            if (hasRole != null)
                DomainEvent.Raise(new DomainNotification("DuplicateName", string.Format(Language.Duplicate, Language.Name)));
            else
            {
                var role = builder.WithName(name)
                    .WithRoleGroup(roleGroup)
                    .Build();

                if(role.IsValid())
                    await repository.CreateAsync(role);
            }
        }

        public void Dispose()
        {
            builder.Dispose();
            repository.Dispose();
        }
    }
}
