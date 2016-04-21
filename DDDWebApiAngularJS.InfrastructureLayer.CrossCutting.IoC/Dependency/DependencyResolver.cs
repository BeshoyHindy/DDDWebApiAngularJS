using DDDWebApiAngularJS.ApplicationLayer.Application.ApplicationServices.Role;
using DDDWebApiAngularJS.ApplicationLayer.Application.ApplicationServices.User;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Builder;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.ApplicationService;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Builder;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Repository;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.Service;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Service;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Builder;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.ApplicationService;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.Builder;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.Repository;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.Service;
using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Service;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Event;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Handler;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Handler.Contract;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Repository.Contract;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.UnitOfWork.Contract;
using DDDWebApiAngularJS.InfrastructureLayer.Data;
using DDDWebApiAngularJS.InfrastructureLayer.Data.Repositories;
using Microsoft.Practices.Unity;

namespace DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.IoC.Dependency
{
    public class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            // UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            // Repositories
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>), new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleRepository, RoleRepository>(new HierarchicalLifetimeManager());

            // Services
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleService, RoleService>(new HierarchicalLifetimeManager());

            // Builders
            container.RegisterType<IUserBuilder, UserBuilder>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleBuilder, RoleBuilder>(new HierarchicalLifetimeManager());

            // ApplicationServices
            container.RegisterType<IUserApplicationService, UserApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleApplicationService, RoleApplicationService>(new HierarchicalLifetimeManager());

            // Handler
            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());
        }
    }
}
