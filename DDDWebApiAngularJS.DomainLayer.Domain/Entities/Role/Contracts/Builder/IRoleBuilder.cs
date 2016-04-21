using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Model;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Builder.Contract;

namespace DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Builder
{
    public interface IRoleBuilder : IBuilder<RoleModel>
    {
        IRoleBuilder WithName(string name);

        IRoleBuilder WithRoleGroup(int roleGroup);
    }
}
