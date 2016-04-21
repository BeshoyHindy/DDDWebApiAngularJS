using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Builder;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Model;
using DDDWebApiAngularJS.DomainLayer.Domain.ValueObjects;

namespace DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Builder
{
    public class RoleBuilder : IRoleBuilder
    {
        public string Name { get; private set; }

        public RoleGroupVO RoleGroup { get; private set; }

        public IRoleBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public IRoleBuilder WithRoleGroup(int roleGroup)
        {
            RoleGroup = (RoleGroupVO)roleGroup;
            return this;
        }

        public RoleModel Build()
        {
            return new RoleModel(Name, RoleGroup);
        }

        public void Dispose()
        {
            Name = string.Empty;
            RoleGroup = 0;
        }
    }
}
