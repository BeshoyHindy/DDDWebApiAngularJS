using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.ApplicationService;
using DDDWebApiAngularJS.PresentationLayer.Api.Utils.Security;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

namespace DDDWebApiAngularJS.PresentationLayer.Api.App_Start
{
    public class OAuthConfig
    {
        public static void ConfigureOAuth(IAppBuilder app, IUserApplicationService applicationService)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true, // False -> utilizar https.
                TokenEndpointPath = new PathString("/api/users/login"), // Url para obter o token.
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2), // Tempo em que o token deve expirar.
                Provider = new AuthorizationServerProvider(applicationService) // Provider de autencação.
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
