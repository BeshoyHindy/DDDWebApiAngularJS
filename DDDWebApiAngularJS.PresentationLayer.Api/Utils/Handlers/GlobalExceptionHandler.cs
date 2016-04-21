using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace DDDWebApiAngularJS.PresentationLayer.Api.Utils.Handlers
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        //public override void Handle(ExceptionHandlerContext context)
        //{
        //    context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.BadRequest, context.Exception.Message));
        //}

        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new TextPlainErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = context.Exception.Message
            };
        }

        private class TextPlainErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent(Content);
                response.RequestMessage = Request;
                return Task.FromResult(response);
            }
        }

        //public override void Handle(ExceptionHandlerContext context)
        //{
        //    var result = new HttpResponseMessage(HttpStatusCode.BadRequest)
        //    {
        //        Content = new StringContent(context.Exception.Message),
        //        ReasonPhrase = context.Exception.Message
        //    };

        //    context.Result = new ExceptionResult(context.Request, result);
        //}

        //public class ExceptionResult : IHttpActionResult
        //{
        //    private HttpRequestMessage request;
        //    private HttpResponseMessage responseMessage;


        //    public ExceptionResult(HttpRequestMessage request, HttpResponseMessage responseMessage)
        //    {
        //        this.request = request;
        //        this.responseMessage = responseMessage;
        //    }

        //    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        //    {
        //        return Task.FromResult(request.CreateResponse(responseMessage));
        //    }
        //}
    }
}