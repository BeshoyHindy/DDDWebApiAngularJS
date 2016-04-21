using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.Service
{
    public interface IUserService : IDisposable
    {
        Task<IEnumerable<UserModel>> GetAllAsync();

        Task<string> GetNameAsync(string email);

        Task<IEnumerable<string>> GetRolesAsync(string email);

        Task<UserModel> LoginAsync(string email, string password);

        Task RegisterAsync(string name, string email, string password, string confirmPassword);
    }
}
