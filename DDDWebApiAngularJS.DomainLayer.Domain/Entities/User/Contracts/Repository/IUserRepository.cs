using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Model;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.Repository
{
    public interface IUserRepository : IRepository<UserModel>
    {
        Task<IEnumerable<UserModel>> GetAllAsync();

        Task<UserModel> GetByIdAsync(Guid id);

        Task<UserModel> GetByEmailAsync(string email);
    }
}
