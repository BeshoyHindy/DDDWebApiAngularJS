using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.ApplicationService;
using DDDWebApiAngularJS.PresentationLayer.Api;
using DDDWebApiAngularJS.PresentationLayer.Api.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Practices.Unity;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]
namespace DDDWebApiAngularJS.PresentationLayer.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            var container = new UnityContainer();
            IoCConfig.ConfigureDependencyInjection(config, container);

            WebApiConfig.ConfigureWebApi(config);

            OAuthConfig.ConfigureOAuth(app, container.Resolve<IUserApplicationService>());

            app.UseCors(CorsOptions.AllowAll);

            app.UseWebApi(config);
        }
    }
}