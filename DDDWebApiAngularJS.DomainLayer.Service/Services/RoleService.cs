using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Builders;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Repository;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Service;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Model;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.DomainLayer.Service.Services
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
            return await repository.GetAllAsync();
        }

        public async Task<IEnumerable<string>> GetRolesAsync()
        {
            return await repository.GetRolesAsync();
        }

        public async Task CreateAsync(string name)
        {
            var hasRole = await repository.GetSingleAsync(x => x.Name.Equals(name));

            if (hasRole != null)
                throw new Exception(string.Format(Language.Duplicate, Language.Name));

            var role = builder.WithName(name)
                .Build();

            role.Validate();

            await repository.CreateAsync(role);
        }

        //public async Task UpdateAsync(string id, string name)
        //{
        //    var role = await repository.GetAsync(Guid.Parse(id));

        //    if (role == null)
        //        throw new Exception(string.Format(Language.NotFound, Language.Role));

        //    if (await repository.GetSingleAsync(x => x.Name.Equals(name)) != null)
        //        throw new Exception(string.Format(Language.Duplicate, Language.Name));

        //    role.ChangeName(name);
        //    role.Validate();

        //    await repository.UpdateAsync(role);
        //}

        //public async Task DeleteAsync(string id)
        //{
        //    var role = await repository.GetAsync(Guid.Parse(id));

        //    if (role == null)
        //        throw new Exception(string.Format(Language.NotFound, Language.Role));

        //    await repository.DeleteAsync(role);
        //}

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
