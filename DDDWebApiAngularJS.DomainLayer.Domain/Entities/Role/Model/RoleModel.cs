using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Model;
using DDDWebApiAngularJS.DomainLayer.Domain.ValueObjects;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Model.Contract;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Resources;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Validations;
using System;
using System.Collections.Generic;

namespace DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Model
{
    public class RoleModel : IModel
    {
        protected RoleModel()
        { }

        public RoleModel(string name, RoleGroupVO roleGroup)
        {
            Id = Guid.NewGuid();
            Name = name;
            RoleGroup = roleGroup;
            Users = new List<UserModel>();
        }

        public virtual Guid Id { get; private set; }

        public virtual string Name { get; private set; }

        public virtual RoleGroupVO RoleGroup { get; private set; }

        public virtual ICollection<UserModel> Users { get; protected set; }

        public virtual void AddUser(UserModel user)
        {
            Users.Add(user);
        }

        public virtual void RemoveUser(UserModel user)
        {
            Users.Remove(user);
        }

        public virtual bool IsValid()
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(Name, string.Format(Language.RequiredM, Language.Name)),
                AssertionConcern.AssertLength(Name, 3, 60, string.Format(Language.Length, Language.Name, 3, 60)),
                AssertionConcern.AssertTrue(RoleGroup != 0, string.Format(Language.RequiredM, Language.Group))
            );
        }
    }
}
