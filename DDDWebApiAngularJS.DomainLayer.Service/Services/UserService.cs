using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Repository;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.Builders;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.Repository;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.Service;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Model;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Resources;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Validations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.DomainLayer.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserBuilder builder;
        private readonly IUserRepository repository;
        private readonly IRoleRepository roleRepository;

        public UserService(IUserBuilder builder, IUserRepository repository, IRoleRepository roleRepository)
        {
            this.builder = builder;
            this.repository = repository;
            this.roleRepository = roleRepository;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return await repository.GetUsersAsync();
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<UserModel> GetSingleAsync(Expression<Func<UserModel, bool>> filter)
        {
            return await repository.GetSingleAsync(filter);
        }

        public async Task<string> GetUserNameAsync(string email)
        {
            return await repository.GetUserNameAsync(email);
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(string email)
        {
            return await repository.GetUserRolesAsync(email);
        }

        public async Task<UserModel> LoginAsync(string email, string password)
        {
            var user = await GetSingleAsync(x => x.Email.Equals(email));

            if (user == null || user.Password != PasswordAssertionConcern.Encrypt(password))
                throw new Exception(string.Format(Language.InvalidF, Language.Credentials));

            return user;
        }

        public async Task RegisterAsync(string name, string email, string password, string confirmPassword)
        {
            if (await GetSingleAsync(x => x.Email.Equals(email)) != null)
                throw new Exception(string.Format(Language.Duplicate, Language.Email));

            var user = builder.WithName(name)
                .WithEmail(email)
                .WithPassword(password)
                .WithConfirmPassword(confirmPassword)
                .Build();

            user.ConfirmPassword(confirmPassword);
            user.Validate();
            user.AddRole(await roleRepository.GetSingleAsync(x => x.Name.Equals("User")));
            //user.AddRole(await roleRepository.GetSingleAsync(x => x.Name.Equals("Admin")));

            await repository.CreateAsync(user);
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
