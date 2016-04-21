using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.ApplicationService;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.Service;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Model;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.UnitOfWork.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.ApplicationLayer.Application.ApplicationServices.User
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserService service;

        public UserApplicationService(IUnitOfWork unitOfWork, IUserService service)
        {
            this.unitOfWork = unitOfWork;
            this.service = service;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await service.GetAllAsync();
        }

        public async Task<string> GetNameAsync(string email)
        {
            return await service.GetNameAsync(email);
        }

        public async Task<IEnumerable<string>> GetRolesAsync(string email)
        {
            return await service.GetRolesAsync(email);
        }

        public async Task<UserModel> LoginAsync(string email, string password)
        {
            return await service.LoginAsync(email, password);
        }

        public async Task RegisterAsync(string name, string email, string password, string confirmPassword)
        {
            unitOfWork.BeginTransaction();
            await service.RegisterAsync(name, email, password, confirmPassword);
            unitOfWork.Commit();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
            service.Dispose();
        }
    }
}
