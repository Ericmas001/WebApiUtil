using System;
using System.Security.Authentication;
using System.Web.Http;

namespace WebApiUtil.Controllers
{
    public class ExceptionsController : ApiController
    {
        // GET api/exceptions/{type}
        public string Get(string type)
        {
            switch (type)
            {
                case "IMPL":
                    throw new NotImplementedException();
                case "AUTH":
                    throw new AuthenticationException();
            }
            throw new Exception();
        }
    }
}