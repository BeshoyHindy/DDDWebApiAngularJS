using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Model;
using DDDWebApiAngularJS.DomainLayer.Domain.ValueObjects;
using FluentNHibernate.Mapping;

namespace DDDWebApiAngularJS.InfrastructureLayer.Data.Mappings
{
    public class RoleMap : ClassMap<RoleModel>
    {
        public RoleMap()
        {
            Table("tb_role");

            Id(x => x.Id)
                .GeneratedBy
                .Assigned()
                .Length(128);

            Map(x => x.Name)
                .Unique()
                .Not
                .Nullable()
                .Length(60);

            Map(x => x.RoleGroup)
                .CustomType<GenericEnumMapper<RoleGroupVO>>()
                .Length(60);

            HasManyToMany(x => x.Users)
                .AsBag()
                .Table("tb_user_role")
                .ParentKeyColumn("role_id")
                .ChildKeyColumn("user_id")
                .Cascade
                .SaveUpdate();
        }
    }
}
