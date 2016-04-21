using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Model;
using DDDWebApiAngularJS.DomainLayer.Domain.ValueObjects;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Model.Contract;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Resources;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Validations;
using System;
using System.Collections.Generic;

namespace DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Model
{
    public class UserModel : IModel
    {
        protected UserModel()
        { }

        public UserModel(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            EmailVO = new EmailVO(email);
            PasswordVO = new PasswordVO(password);
            Roles = new List<RoleModel>();
        }

        public virtual Guid Id { get; private set; }

        public virtual string Name { get; private set; }

        public virtual EmailVO EmailVO { get; private set; }

        public virtual PasswordVO PasswordVO { get; private set; }

        public virtual ICollection<RoleModel> Roles { get; protected set; }

        public virtual bool ConfirmPassword(string confirmPassword)
        {
            return PasswordVO.ConfirmPassword(confirmPassword);
        }

        public virtual void EncryptPassword()
        {
            PasswordVO.Encrypt();
        }

        public virtual void AddRole(RoleModel role)
        {
            Roles.Add(role);
        }

        public virtual void RemoveRole(RoleModel role)
        {
            Roles.Remove(role);
        }

        public virtual bool IsValid()
        {
            return EmailVO.IsValid() &&
            PasswordVO.IsValid() &&
            AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(Name, string.Format(Language.InvalidF, Language.Name)),
                AssertionConcern.AssertLength(Name, 3, 60, string.Format(Language.Length, Language.Name, 3, 60))
            );
        }
    }
}