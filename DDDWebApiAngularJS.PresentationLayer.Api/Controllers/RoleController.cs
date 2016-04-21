using DDDWebApiAngularJS.DomainLayer.Domain.Entities.Role.Contracts.ApplicationService;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Resources;
using DDDWebApiAngularJS.PresentationLayer.Api.Controllers.Base;
using DDDWebApiAngularJS.PresentationLayer.Api.Utils.Attributes;
using DDDWebApiAngularJS.PresentationLayer.Api.ViewModels.Role;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace DDDWebApiAngularJS.PresentationLayer.Api.Controllers
{
    [RoutePrefix("api/roles")]
    [Authorize(Roles = "Admin")]
    public class RoleController : BaseApiController
    {
        private readonly IRoleApplicationService applicationService;

        public RoleController(IRoleApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }
        
        [HttpGet]
        [Route("")]
        [DeflateCompression]
        //[CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)] //Install-Package Strathweb.CacheOutput.WebApi2
        public async Task<HttpResponseMessage> GetAsync()
        {
            return await CreateResponse(HttpStatusCode.OK, applicationService.GetAllAsync().Result);
        }

        [HttpPost]
        [Route("new")]
        public async Task<HttpResponseMessage> PostAsync(NewRoleViewModel role)
        {
            await applicationService.CreateAsync(role.Name, role.RoleGroup);

            return await CreateResponse(HttpStatusCode.Created, Language.SuccessOperation);
        }

        //[HttpPut]
        //[Route("edit")]
        //public async Task<HttpResponseMessage> PutAsync(UpdateViewModel model)
        //{
        //    await service.UpdateAsync(model.Id, model.Name);
        //    return await CreateResponse(HttpStatusCode.OK, Language.SuccessOperation);
        //}

        //[HttpDelete]
        //[Route("delete")]
        //public async Task<HttpResponseMessage> Delete(DeleteViewModel model)
        //{
        //    await service.DeleteAsync(model.Id);
        //    return await CreateResponse(HttpStatusCode.OK, Language.SuccessOperation);
        //}

        protected override void Dispose(bool disposing)
        {
            notifications.Dispose();
            applicationService.Dispose();
        }
    }
}
