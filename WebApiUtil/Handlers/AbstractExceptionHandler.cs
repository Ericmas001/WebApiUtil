using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace WebApiUtil.Handlers
{
    public abstract class AbstractExceptionHandler : ExceptionHandler
    {
        protected Dictionary<Type, HttpStatusCode> Exceptions { get; } = new Dictionary<Type, HttpStatusCode>
        {
            {typeof(NotImplementedException), HttpStatusCode.NotImplemented},
            {typeof(AuthenticationException), HttpStatusCode.Unauthorized}
        };

        public override void Handle(ExceptionHandlerContext context)
        {
            base.Handle(context);
            context.Result = new ResponseMessageResult(GetResponseMessage(context));
        }

        protected abstract HttpResponseMessage GetResponseMessage(ExceptionHandlerContext context);

        public virtual HttpStatusCode GetHttpStatusCode(Exception e)
        {
            if (Exceptions.ContainsKey(e.GetType()))
                return Exceptions[e.GetType()];

            return HttpStatusCode.InternalServerError;
        }
    }
}