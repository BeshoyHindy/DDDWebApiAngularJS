using DDDWebApiAngularJS.DomainLayer.SharedKernel.Event;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Handler.Contract;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DDDWebApiAngularJS.PresentationLayer.Api.Controllers.Base
{
    [Authorize(Roles = "User")]
    public class BaseApiController : ApiController
    {
        public IHandler<DomainNotification> notifications;
        private HttpResponseMessage responseMessage;

        public BaseApiController()
        {
            notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
            responseMessage = new HttpResponseMessage();
        }

        public Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            if (notifications.HasNotifications())
                responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = notifications.Notify() });
            else
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, result);

            return Task.FromResult(responseMessage);
        }
    }
}
