using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebApiUtil.Filters
{
    public class NotImplementedExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            base.OnException(context);

            if (context.Exception.GetType() == typeof(NotImplementedException))
                context.Response = context.Request.CreateResponse(HttpStatusCode.NotImplemented);
        }
    }
}