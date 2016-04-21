using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.Repository;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Model;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.UnitOfWork.Contract;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.InfrastructureLayer.Data.Repositories
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return Task.FromResult(
                session.Query<UserModel>()
                    .AsEnumerable()
            );
        }

        public Task<UserModel> GetByIdAsync(Guid id)
        {
            return Task.FromResult(
                session.Get<UserModel>(id)
            );
        }

        public Task<UserModel> GetByEmailAsync(string email)
        {
            return Task.FromResult(
                session.Query<UserModel>()
                    .Where(x => x.EmailVO.Email.Equals(email))
                    .FirstOrDefault()
            );
        }
    }
}
