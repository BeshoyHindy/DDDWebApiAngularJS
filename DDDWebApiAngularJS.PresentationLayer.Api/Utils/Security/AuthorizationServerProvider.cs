using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.ApplicationService;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Resources;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DDDWebApiAngularJS.PresentationLayer.Api.Utils.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserApplicationService applicationService;

        public AuthorizationServerProvider(IUserApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var user = await applicationService.LoginAsync(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", string.Format(Language.InvalidF, Language.Credentials));
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, user.EmailVO.Email));

                foreach (var role in user.Roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleGroup.ToString()));
                }

                context.Validated(identity);
            }
            catch(Exception)
            {
                context.SetError("invalid_grant", string.Format(Language.InvalidF, Language.Credentials));
            }
        }
    }
}