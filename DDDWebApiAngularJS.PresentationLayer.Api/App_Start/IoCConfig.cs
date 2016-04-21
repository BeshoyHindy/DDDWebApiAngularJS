using DDDWebApiAngularJS.DomainLayer.SharedKernel.Event;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.IoC.Dependency;
using DDDWebApiAngularJS.PresentationLayer.Api.Utils.Helpers;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace DDDWebApiAngularJS.PresentationLayer.Api.App_Start
{
    public class IoCConfig
    {
        public static void ConfigureDependencyInjection(HttpConfiguration config, UnityContainer container)
        {
            DependencyResolver.Resolve(container);
            config.DependencyResolver = new UnityResolverHelper(container);
            DomainEvent.Container = new DomainEventsContainerHelper(config.DependencyResolver);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
