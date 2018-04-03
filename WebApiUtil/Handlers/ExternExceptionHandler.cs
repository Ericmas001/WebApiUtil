using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace WebApiUtil.Handlers
{
    public class ExternExceptionHandler : AbstractExceptionHandler
    {
        protected override HttpResponseMessage GetResponseMessage(ExceptionHandlerContext context)
        {
            return context.Request.CreateResponse(GetHttpStatusCode(context.Exception));
        }
    }
}