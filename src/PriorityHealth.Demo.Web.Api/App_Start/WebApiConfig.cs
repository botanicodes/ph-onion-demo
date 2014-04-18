using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PriorityHealth.Demo.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Remove XML Formats
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
