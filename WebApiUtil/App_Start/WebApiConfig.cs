using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;
using Unity;

namespace WebApiUtil
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
            config.Services.Replace(typeof(IFilterProvider), new UnityFilterProvider(UnityConfig.Container));

            if (UnityConfig.Container.IsRegistered(typeof(IExceptionHandler)))
                config.Services.Replace(typeof(IExceptionHandler), UnityConfig.Container.Resolve<IExceptionHandler>());

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
