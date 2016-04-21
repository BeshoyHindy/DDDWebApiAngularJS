using DDDWebApiAngularJS.DomainLayer.Domain.Entities.User.Contracts.ApplicationService;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Resources;
using DDDWebApiAngularJS.PresentationLayer.Api.Controllers.Base;
using DDDWebApiAngularJS.PresentationLayer.Api.Utils.Attributes;
using DDDWebApiAngularJS.PresentationLayer.Api.ViewModels.User;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace DDDWebApiAngularJS.PresentationLayer.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : BaseApiController
    {
        private readonly IUserApplicationService applicationService;

        public UserController(IUserApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }
        
        [HttpGet]
        [Route("")]
        [DeflateCompression]
        [Authorize(Roles = "Admin")]
        //[CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)] //Install-Package Strathweb.CacheOutput.WebApi2
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            return await CreateResponse(HttpStatusCode.OK, applicationService.GetAllAsync().Result);
        }
        
        [HttpGet]
        [Route("name")]
        [DeflateCompression]
        //[CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)] //Install-Package Strathweb.CacheOutput.WebApi2
        public async Task<HttpResponseMessage> GetNameAsync(string email)
        {
            return await CreateResponse(HttpStatusCode.OK, applicationService.GetNameAsync(email).Result);
        }
        
        [HttpGet]
        [Route("roles")]
        [DeflateCompression]
        //[CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)] //Install-Package Strathweb.CacheOutput.WebApi2
        public async Task<HttpResponseMessage> GetRolesAsync(string email)
        {
            return await CreateResponse(HttpStatusCode.OK, applicationService.GetRolesAsync(email).Result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<HttpResponseMessage> RegisterAsync(RegisterViewModel viewModel)
        {
            await applicationService.RegisterAsync(viewModel.Name, viewModel.Email, viewModel.Password, viewModel.ConfirmPassword);

            return await CreateResponse(HttpStatusCode.Created, Language.SuccessOperation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                notifications.Dispose();
                applicationService.Dispose();
            }
        }
    }
}
