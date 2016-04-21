using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Model;
using FluentNHibernate.Mapping;

namespace DDDWebApiAngularJS.InfrastructureLayer.Data.Mappings
{
    public class UserMap : ClassMap<UserModel>
    {
        public UserMap()
        {
            Table("tb_user");

            Id(x => x.Id)
                .GeneratedBy
                .Assigned()
                .Length(128);

            Map(x => x.Name)
                .Not
                .Nullable()
                .Length(60);

            Component(x => x.EmailVO, m => m.Map(x => x.Email)
                .Unique()
                .Not
                .Nullable()
                .Length(256));

            Component(x => x.PasswordVO, m => m.Map(x => x.Password)
                .Not
                .Nullable()
                .Length(128));

            HasManyToMany(x => x.Roles)
                .AsBag()
                .Table("tb_user_role")
                .ParentKeyColumn("user_id")
                .ChildKeyColumn("role_id")
                .Cascade
                .SaveUpdate();
        }
    }
}
