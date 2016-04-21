using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Model;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Builder.Contract;

namespace DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.Builder
{
    public interface IUserBuilder : IBuilder<UserModel>
    {
        IUserBuilder WithName(string name);

        IUserBuilder WithEmail(string email);

        IUserBuilder WithPassword(string password);
    }
}
